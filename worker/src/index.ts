import schedule from "node-schedule";

import { processScheduledRooms } from "./jobs/processScheduledRooms";

// Schedule the worker to run every 10 seconds
schedule.scheduleJob("*/10 * * * * *", async () => {
  await processScheduledRooms();
});
