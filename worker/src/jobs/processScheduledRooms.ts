import { PoolClient } from "pg";

import { getClient } from "../config/database";
import { transporter } from "../config/email";
import { renderTemplate } from "../utils/templateRenderer";

interface Participant {
  email: string;
  roomTitle: string;
  scheduledAt: string;
  userId: string;
  roomId: string;
}

const getParticipants = async (client: PoolClient) => {
  console.log("Checking for scheduled rooms...");

  const query = `
    SELECT rp."UserId", u.email, r.title AS "roomTitle", r."ScheduledAt", rp."RoomId"
    FROM "RoomParticipants" rp
    INNER JOIN "Rooms" r ON rp."RoomId" = r.id
    INNER JOIN "Users" u ON rp."UserId" = u.id
    WHERE r."ScheduledAt" <= NOW() + interval '5 minutes'
      AND r."ScheduledAt" > NOW()
      AND rp."NotifiedAt" IS NULL
  `;
  const { rows }: { rows: Participant[] } = await client.query(query);

  if (rows.length === 0) {
    console.log("No participants to notify.");
    return [];
  }

  return rows;
};

export const processScheduledRooms = async (): Promise<void> => {
  const client = await getClient();

  try {
    const participants = await getParticipants(client);
    for (const participant of participants) {
      try {
        const emailContent = renderTemplate("reminder", {
          name: participant.userId,
          roomTitle: participant.roomTitle,
          scheduledAt: participant.scheduledAt,
          year: new Date().getFullYear(),
        });

        await transporter.sendMail({
          from: process.env.EMAIL_USER,
          to: participant.email,
          subject: `Reminder: Room "${participant.roomTitle}" Scheduled`,
          html: emailContent,
        });

        console.log(
          `Email sent to ${participant.email} for Room ID ${participant.roomId}`
        );

        await client.query(
          `UPDATE "RoomParticipants" SET "NotifiedAt" = NOW() WHERE "RoomId" = $1 AND "UserId" = $2`,
          [participant.roomId, participant.userId]
        );
      } catch (err) {
        console.error(
          `Failed to notify user ${participant.userId} for Room ${participant.roomId}:`,
          err
        );
      }
    }
  } catch (err) {
    console.error("Error processing scheduled rooms:", err);
  } finally {
    client.release();
  }
};
