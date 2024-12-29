import fs from "fs";
import path from "path";

import handlebars from "handlebars";

export const renderTemplate = (
  templateName: string,
  data: Record<string, any>
): string => {
  const templatePath = path.join(
    __dirname,
    "..",
    "templates",
    `${templateName}.html`
  );
  const templateSource = fs.readFileSync(templatePath, "utf-8");
  const template = handlebars.compile(templateSource);
  return template(data);
};
