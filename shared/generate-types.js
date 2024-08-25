require("dotenv").config({ path: ".env.local" });
const { exec } = require("child_process");

const apiUrl = process.env.API_URL;

if (!apiUrl) {
  console.error("API_BASE_URL is not defined in .env");
  process.exit(1);
}

const command = `pnpm openapi-generator-cli generate -i ${apiUrl}/swagger/v1/swagger.json -g typescript-fetch -o ./src/types/openApiGen --type-mappings=RoomStatus=string`;

exec(command, (err, stdout, stderr) => {
  if (err) {
    console.error(`Error generating types: ${err}`);
    return;
  }
  console.log(`Output: ${stdout}`);
  if (stderr) {
    console.error(`Error: ${stderr}`);
  }
});
