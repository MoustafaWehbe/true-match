using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Text.Json;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class userProfileGenderPreference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "895c6a7c-36e1-4e66-bfe2-abf99fbac40f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d78cfc52-53f6-439e-909a-a12254eaaa54");

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("05cbebab-f5cb-4a09-9b6b-e69cc80b170b"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("0d1ee1ae-5720-4b2c-8f19-39dbb3efb3d5"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("189e251e-06d4-4c02-b532-7c0ead76cf25"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("36fc7720-0a8f-4b08-8d2a-95beff04a29d"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("4398cce0-3204-4a4a-baf6-a77c9e80f426"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("470743f2-35b8-4f95-bd44-5ca0ada83a52"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("5fc85dc1-9ae0-4402-b564-311bd288caad"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("68924bae-c5de-4987-a3c1-67f226f2c33a"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("6f132bdd-51bf-4840-8b76-312e8bbc989d"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("873c6fb0-bdaf-4449-b026-5c4b9c4a0409"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("8d4d6b90-bc2c-495d-ad78-bfd436b16fc5"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("9708700b-34be-4b54-a904-ec95bcf5cead"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("a6bc74aa-e235-4211-bb31-3ef16774d88f"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("b6d8a7a9-8ac5-421d-9a88-17b3b9df5243"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("c7d392f7-293e-4969-b9d8-ef416df9c517"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("d7c76ad0-d770-4b4f-865d-c809310b4f76"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("e6bbebd9-b191-460f-9472-7c4f9e71b6ad"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("e8175bac-4ee7-4605-80bf-c4bc2906cad3"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("f1ea2c16-40dd-49f5-a982-4ab11ab162be"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("f9909746-a4b6-4d76-a24a-9c293dd8ceaa"));

            migrationBuilder.DeleteData(
                table: "RoomContent",
                keyColumn: "Id",
                keyValue: new Guid("212842a5-9e8b-48bc-a641-c1005bb8b3d7"));

            migrationBuilder.DeleteData(
                table: "RoomContent",
                keyColumn: "Id",
                keyValue: new Guid("4d82fb65-d616-4953-a4e7-fe5c5b7b3d6b"));

            migrationBuilder.DeleteData(
                table: "RoomContent",
                keyColumn: "Id",
                keyValue: new Guid("8e408eee-0ed7-4199-8612-c851d127563d"));

            migrationBuilder.DeleteData(
                table: "RoomContent",
                keyColumn: "Id",
                keyValue: new Guid("e519ab86-a2f2-49cc-b76f-670d853e8f74"));

            migrationBuilder.DeleteData(
                table: "RoomContent",
                keyColumn: "Id",
                keyValue: new Guid("f7b4c72c-d2fe-411d-9e78-331259f14d44"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("010ad1dd-e62e-42e0-8897-9079192a2eae"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("068410e4-017b-4a7f-93e9-adaec48a8e97"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("07b1fe5e-cb80-47b2-8243-14b7eb9052d5"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("09ebc59b-afd8-4d26-8754-fde26891aa79"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("18f33003-f0ab-4fcf-8504-4388422a5960"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("22eb7d19-724a-41ff-80e3-2664a1637e6e"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("26af3051-c5e3-4be6-86dc-f3db62ff1596"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("2caac5fd-2ae2-4b3c-98ff-83dc2fc4245a"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("2e2ee7a5-d820-4cdb-80b1-e3fede9315e0"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("2eb1b4fb-3153-45ae-91b1-1e3292394a4a"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("30897864-329a-4b31-9734-24431b09a1c9"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("35d96d33-3e06-45f3-8d7f-0c2ebee86367"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("3708badb-fe39-4c32-a6ed-f53f985c29de"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("3af295e8-f104-49c9-9aa6-e86653b3edf3"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("3d861057-2ebe-4bc7-80b4-a45818de8b7a"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("40d6b357-8672-4cda-a787-89104d7242d4"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("46b1d1f3-c52c-4830-8af4-cbbefbd908e3"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("5129f301-67eb-4409-a63f-1ee1d7818139"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("57ae497a-42cb-4ab2-954d-7e1d6530657b"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("5a25cf8f-c3d8-46dc-bdc1-7a678967d0db"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("5a9ea3c8-c13f-4a03-98e8-b3afc5c464f8"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("5b1b1cfa-68aa-4dac-9158-83cc09614fbd"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("5d8baeed-c97c-4ee8-838a-92a1e9c35b57"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("63bbe4c1-0663-4c81-8a1d-560d908beed7"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("64236237-303b-413f-a85e-6995567bdb87"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("67fb3e02-5f57-446a-80ec-6ef68fc1f46c"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("6a70650d-2aee-4856-89cd-9e3b85138eaa"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("6abb0974-9ef4-4b81-9fe0-91ea86214709"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("6b25e225-2219-4ea1-9d29-0d181e5c3800"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("70ba2d93-3e2e-4bd0-b8e2-bcf519958a17"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("749ba5de-0cf0-407f-8330-0cbcd99a6a9f"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("767ab92d-8117-477a-bfd1-576efc3380d8"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("7a12bd37-ef52-4d67-952f-a3dad415fd36"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("7b0f9739-407d-4a60-8c02-5e81767d94d6"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("7b16abbd-1d06-46c2-9638-709c34817d01"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("81590d97-0fcf-4a92-92b1-29a2e202c458"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("8375d127-afb9-4205-ae3e-f1bf05b2b488"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("853a5bd1-7152-4fc8-a858-302134325962"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("855036c3-db5b-43bb-bb44-a293ba965fba"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("8702c46f-dd37-4ce5-821d-e1d400a6d916"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("89fd183b-2f5c-4f30-916e-b981b0e0ca8b"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("92ed913a-d93e-47cc-be7b-b2186aa44af5"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("938bca5a-7cc1-4fd0-9710-29ece719558c"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("94244795-9802-43d7-83a6-88e4fe5f745b"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("94c34a14-37cb-43b8-a20b-44ae8dc782f1"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("94f04d37-a585-4c54-a131-1639f942d077"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("98458966-8deb-4acd-97df-abeaed0f3232"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("9a121386-672a-41bb-a5cd-969c57ae19da"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("a37b78d3-e34f-45f4-8b7f-36b1dcc8c131"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("a4139abd-418a-4c37-8b9e-df10bfe6efe7"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("a54a501d-1f45-43bd-9dcb-e981f282c0e5"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("a604f987-ca3f-4a46-948e-ad79e071594c"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("ab174561-0f43-493a-ab79-8be1fc7465e8"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("af90c16e-8f0e-4bc9-90aa-5883588db8d4"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("b04a27a6-c780-4490-aaa4-3d3a5c48b902"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("b19c4fca-b7e1-4d34-ba65-2660b694d186"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("b1f0014a-eed1-4de4-8454-c5844d5ed2f8"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("b23d40d8-e7ec-4382-b766-9b831076ae06"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("b3e42a73-a830-4aac-b805-6911627ffa95"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("ba46b3bb-15a9-4f53-9b6c-7825b34da75e"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("bc44673f-2efb-49aa-b55c-18cb14f3d641"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("be7aa718-99f0-4ffb-8f82-bab82383135b"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("c5afe04f-c319-4bb3-8be9-f51735a0890f"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("c616a239-c55a-42fa-b0ed-964be5fbcb21"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("c9f7cd6d-5e07-4e4a-b0c3-6cb09b8124b7"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("ca473ed6-4652-45fc-be92-226b4cb60bcf"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("cdda0fe1-8261-493d-bb63-1c40b47ecba5"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("cfd1e62b-1b8b-4737-b440-4adaf0490169"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("d04bb78d-f8a0-4577-98a3-bc700472d266"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("d1ab3bbc-538f-4462-9903-ea3df011e31c"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("d22893a8-cf57-41b5-91d2-29c6e06ac895"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("d6f20102-e99c-456a-ae4e-215200700cb1"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("d76225a8-f791-4780-82f6-08d68d9448d3"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("d7a5f829-e2d2-4393-8f1d-d36d817f2bd7"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("dc4b6457-a516-498d-a73a-b971a8a6b1b5"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("dd3afa44-c7c4-4553-bf9f-8d596b26254b"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("df289085-afeb-470f-bc73-eeb1d15ab362"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("dfa7f43d-065b-4c6f-b7f2-798e42295261"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("e1dff12d-6255-46fb-a0e8-3580dc1c70a8"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("e332b4ea-55cb-4535-84a4-9ee656dddcf5"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("e363f864-f107-461a-b7d4-ea44ee2fb4b8"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("ebacb433-19e0-4dae-8e86-ff4e8010f423"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f13bd981-833d-4e7e-b860-89acb2286909"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f2a1cd16-a41b-4722-a2ef-06134aa05d95"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f5413d7d-3897-4117-9c83-836878b090ec"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f6ff4720-261f-46ba-9915-dd5f3021eac5"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f73f2b1b-7909-400d-9052-837cc101c2f9"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f9237174-afa2-463f-8045-716a896025ca"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f9b037c0-29fb-434d-a658-03f552a11ca5"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("fc94d573-4127-4972-9061-a1018de510e2"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("fd46e021-6190-4938-819c-b3cbad7880be"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("4cdd2b8e-5005-491b-a513-e3a2d7ac37ce"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("6adbf96a-6fd2-405b-95d1-d9edc442723f"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("8708c64a-4e8c-4a31-86c1-98d9d678c124"));

            migrationBuilder.DeleteData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"));

            migrationBuilder.DeleteData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: new Guid("1c275fd6-53c1-4521-8d9a-501a1e57b872"));

            migrationBuilder.DeleteData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: new Guid("2ddab326-f330-481b-a6d8-73a8aa1d715a"));

            migrationBuilder.DeleteData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: new Guid("2ff7af7f-4e4f-4508-aa00-1ff45de82467"));

            migrationBuilder.DeleteData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: new Guid("ae9dd40b-b6b3-4f7f-a299-951ecd31235a"));

            migrationBuilder.DeleteData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: new Guid("f9d7cd77-d00f-4f90-ae3c-031b58519c07"));

            migrationBuilder.AddColumn<List<Guid>>(
                name: "UserProfileGenderPreferences",
                table: "UserProfiles",
                type: "uuid[]",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8bf1dc63-e8bb-47ee-8c6a-28c5b90d15d5", null, "User", "USER" },
                    { "e23f453a-bc99-44c9-a2b5-211f2118d3f5", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AvailableDescriptors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Descriptors",
                value: System.Text.Json.JsonDocument.Parse("[\n        {\n          \"id\": \"de_30\",\n          \"prompt\": \"Here’s where you can add your height to your profile.\",\n          \"type\": \"measurement\",\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/height@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/height@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 16,\n              \"height\": 16\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/height@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 32,\n              \"height\": 32\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/height@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 48,\n              \"height\": 48\n            }\n          ],\n          \"backgroundText\": \"Add height\",\n          \"measurableDetails\": {\n            \"min\": 90,\n            \"max\": 241,\n            \"unitOfMeasure\": \"cm\",\n            \"defaultUnitOfMeasure\": \"cm\"\n          },\n          \"sectionId\": 1,\n          \"sectionName\": \"Height\",\n          \"matchGroupKey\": \"height\",\n          \"discoveryPreferencesEnabled\": false\n        }\n      ]", new System.Text.Json.JsonDocumentOptions()));

            migrationBuilder.UpdateData(
                table: "AvailableDescriptors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Descriptors",
                value: System.Text.Json.JsonDocument.Parse("[\n        {\n          \"id\": \"de_37\",\n          \"type\": \"multiSelectionSet\",\n          \"choices\": [\n            {\n              \"id\": \"it_2275\",\n              \"name\": \"Harry Potter\"\n            },\n            {\n              \"id\": \"it_2033\",\n              \"name\": \"’90s kid\"\n            },\n            {\n              \"id\": \"it_2396\",\n              \"name\": \"SoundCloud\"\n            },\n            {\n              \"id\": \"it_2397\",\n              \"name\": \"Spa\"\n            },\n            {\n              \"id\": \"it_2155\",\n              \"name\": \"Self-care\"\n            },\n            {\n              \"id\": \"it_2276\",\n              \"name\": \"Heavy metal\"\n            },\n            {\n              \"id\": \"it_2031\",\n              \"name\": \"House parties\"\n            },\n            {\n              \"id\": \"it_2152\",\n              \"name\": \"Gin & tonic\"\n            },\n            {\n              \"id\": \"it_2273\",\n              \"name\": \"Gymnastics\"\n            },\n            {\n              \"id\": \"it_2279\",\n              \"name\": \"Hot yoga\"\n            },\n            {\n              \"id\": \"it_2159\",\n              \"name\": \"Meditation\"\n            },\n            {\n              \"id\": \"it_2398\",\n              \"name\": \"Spotify\"\n            },\n            {\n              \"id\": \"it_2035\",\n              \"name\": \"Sushi\"\n            },\n            {\n              \"id\": \"it_2277\",\n              \"name\": \"Hockey\"\n            },\n            {\n              \"id\": \"it_2156\",\n              \"name\": \"Basketball\"\n            },\n            {\n              \"id\": \"it_2036\",\n              \"name\": \"Slam poetry\"\n            },\n            {\n              \"id\": \"it_2278\",\n              \"name\": \"Home workouts\"\n            },\n            {\n              \"id\": \"it_2157\",\n              \"name\": \"Theatre\"\n            },\n            {\n              \"id\": \"it_33\",\n              \"name\": \"Café hopping\"\n            },\n            {\n              \"id\": \"it_36\",\n              \"name\": \"Aquarium\"\n            },\n            {\n              \"id\": \"it_2039\",\n              \"name\": \"Trainers\"\n            },\n            {\n              \"id\": \"it_35\",\n              \"name\": \"Instagram\"\n            },\n            {\n              \"id\": \"it_30\",\n              \"name\": \"Hot springs\"\n            },\n            {\n              \"id\": \"it_31\",\n              \"name\": \"Walking\"\n            },\n            {\n              \"id\": \"it_4\",\n              \"name\": \"Running\"\n            },\n            {\n              \"id\": \"it_7\",\n              \"name\": \"Travel\"\n            },\n            {\n              \"id\": \"it_6\",\n              \"name\": \"Language exchange\"\n            },\n            {\n              \"id\": \"it_9\",\n              \"name\": \"Films\"\n            },\n            {\n              \"id\": \"it_2271\",\n              \"name\": \"Guitarists\"\n            },\n            {\n              \"id\": \"it_2392\",\n              \"name\": \"Social development\"\n            },\n            {\n              \"id\": \"it_2272\",\n              \"name\": \"Gym\"\n            },\n            {\n              \"id\": \"it_2393\",\n              \"name\": \"Social media\"\n            },\n            {\n              \"id\": \"it_2030\",\n              \"name\": \"Hip hop\"\n            },\n            {\n              \"id\": \"it_2390\",\n              \"name\": \"Skincare\"\n            },\n            {\n              \"id\": \"it_2022\",\n              \"name\": \"J-Pop\"\n            },\n            {\n              \"id\": \"it_2386\",\n              \"name\": \"Shisha\"\n            },\n            {\n              \"id\": \"it_2023\",\n              \"name\": \"Cricket\"\n            },\n            {\n              \"id\": \"it_2262\",\n              \"name\": \"Freelance\"\n            },\n            {\n              \"id\": \"it_2389\",\n              \"name\": \"Skateboarding\"\n            },\n            {\n              \"id\": \"it_2268\",\n              \"name\": \"Gospel\"\n            },\n            {\n              \"id\": \"it_27\",\n              \"name\": \"K-Pop\"\n            },\n            {\n              \"id\": \"it_2027\",\n              \"name\": \"Potterhead\"\n            },\n            {\n              \"id\": \"it_26\",\n              \"name\": \"Trying new things\"\n            },\n            {\n              \"id\": \"it_29\",\n              \"name\": \"Photography\"\n            },\n            {\n              \"id\": \"it_2024\",\n              \"name\": \"Bollywood\"\n            },\n            {\n              \"id\": \"it_28\",\n              \"name\": \"Reading\"\n            },\n            {\n              \"id\": \"it_2388\",\n              \"name\": \"Singing\"\n            },\n            {\n              \"id\": \"it_23\",\n              \"name\": \"Sports\"\n            },\n            {\n              \"id\": \"it_2028\",\n              \"name\": \"Poetry\"\n            },\n            {\n              \"id\": \"it_2029\",\n              \"name\": \"Stand-up comedy\"\n            },\n            {\n              \"id\": \"it_1\",\n              \"name\": \"Coffee\"\n            },\n            {\n              \"id\": \"it_3\",\n              \"name\": \"Karaoke\"\n            },\n            {\n              \"id\": \"it_2260\",\n              \"name\": \"Fortnite\"\n            },\n            {\n              \"id\": \"it_2261\",\n              \"name\": \"Free diving\"\n            },\n            {\n              \"id\": \"it_2382\",\n              \"name\": \"Self-development\"\n            },\n            {\n              \"id\": \"it_2055\",\n              \"name\": \"Mental health awareness\"\n            },\n            {\n              \"id\": \"it_19\",\n              \"name\": \"Foodie tour\"\n            },\n            {\n              \"id\": \"it_2053\",\n              \"name\": \"Voter rights\"\n            },\n            {\n              \"id\": \"it_2295\",\n              \"name\": \"Jiu-jitsu\"\n            },\n            {\n              \"id\": \"it_2054\",\n              \"name\": \"Climate change\"\n            },\n            {\n              \"id\": \"it_16\",\n              \"name\": \"Exhibition\"\n            },\n            {\n              \"id\": \"it_15\",\n              \"name\": \"Walking my dog\"\n            },\n            {\n              \"id\": \"it_2057\",\n              \"name\": \"LGBTQIA+ rights\"\n            },\n            {\n              \"id\": \"it_2058\",\n              \"name\": \"Feminism\"\n            },\n            {\n              \"id\": \"it_12\",\n              \"name\": \"VR room\"\n            },\n            {\n              \"id\": \"it_11\",\n              \"name\": \"Escape café\"\n            },\n            {\n              \"id\": \"it_14\",\n              \"name\": \"Shopping\"\n            },\n            {\n              \"id\": \"it_10\",\n              \"name\": \"Brunch\"\n            },\n            {\n              \"id\": \"it_2290\",\n              \"name\": \"Investment\"\n            },\n            {\n              \"id\": \"it_2293\",\n              \"name\": \"Jet skiing\"\n            },\n            {\n              \"id\": \"it_2172\",\n              \"name\": \"Reggaeton\"\n            },\n            {\n              \"id\": \"it_2051\",\n              \"name\": \"Vintage clothing\"\n            },\n            {\n              \"id\": \"it_2052\",\n              \"name\": \"Black Lives Matter\"\n            },\n            {\n              \"id\": \"it_2294\",\n              \"name\": \"Jogging\"\n            },\n            {\n              \"id\": \"it_2050\",\n              \"name\": \"Road trips\"\n            },\n            {\n              \"id\": \"it_2171\",\n              \"name\": \"Vintage fashion\"\n            },\n            {\n              \"id\": \"it_2165\",\n              \"name\": \"Voguing\"\n            },\n            {\n              \"id\": \"it_2166\",\n              \"name\": \"Sofa surfing\"\n            },\n            {\n              \"id\": \"it_2163\",\n              \"name\": \"Happy hour\"\n            },\n            {\n              \"id\": \"it_2285\",\n              \"name\": \"Inclusivity\"\n            },\n            {\n              \"id\": \"it_2048\",\n              \"name\": \"Country music\"\n            },\n            {\n              \"id\": \"it_2049\",\n              \"name\": \"Football\"\n            },\n            {\n              \"id\": \"it_2288\",\n              \"name\": \"Rollerblading\"\n            },\n            {\n              \"id\": \"it_2289\",\n              \"name\": \"Investing\"\n            },\n            {\n              \"id\": \"it_2161\",\n              \"name\": \"Tennis\"\n            },\n            {\n              \"id\": \"it_2282\",\n              \"name\": \"Ice cream\"\n            },\n            {\n              \"id\": \"it_2283\",\n              \"name\": \"Ice skating\"\n            },\n            {\n              \"id\": \"it_2280\",\n              \"name\": \"Human rights\"\n            },\n            {\n              \"id\": \"it_2160\",\n              \"name\": \"Exhibitions\"\n            },\n            {\n              \"id\": \"it_2352\",\n              \"name\": \"Pig roast\"\n            },\n            {\n              \"id\": \"it_1021\",\n              \"name\": \"Skiing\"\n            },\n            {\n              \"id\": \"it_2232\",\n              \"name\": \"Canoeing\"\n            },\n            {\n              \"id\": \"it_2111\",\n              \"name\": \"West End musicals\"\n            },\n            {\n              \"id\": \"it_1022\",\n              \"name\": \"Snowboarding\"\n            },\n            {\n              \"id\": \"it_2353\",\n              \"name\": \"Pilates\"\n            },\n            {\n              \"id\": \"it_2351\",\n              \"name\": \"Pentathlon\"\n            },\n            {\n              \"id\": \"it_2230\",\n              \"name\": \"Broadway\"\n            },\n            {\n              \"id\": \"it_2356\",\n              \"name\": \"PlayStation\"\n            },\n            {\n              \"id\": \"it_2235\",\n              \"name\": \"Cheerleading\"\n            },\n            {\n              \"id\": \"it_2236\",\n              \"name\": \"Choir\"\n            },\n            {\n              \"id\": \"it_2357\",\n              \"name\": \"Pole dancing\"\n            },\n            {\n              \"id\": \"it_2115\",\n              \"name\": \"Five-a-side football\"\n            },\n            {\n              \"id\": \"it_2233\",\n              \"name\": \"Car racing\"\n            },\n            {\n              \"id\": \"it_2354\",\n              \"name\": \"Pinterest\"\n            },\n            {\n              \"id\": \"it_2113\",\n              \"name\": \"Pub quiz\"\n            },\n            {\n              \"id\": \"it_1024\",\n              \"name\": \"Festivals\"\n            },\n            {\n              \"id\": \"it_2234\",\n              \"name\": \"Catan\"\n            },\n            {\n              \"id\": \"it_2239\",\n              \"name\": \"Cosplay\"\n            },\n            {\n              \"id\": \"it_2119\",\n              \"name\": \"Motor sports\"\n            },\n            {\n              \"id\": \"it_2237\",\n              \"name\": \"Coffee stands\"\n            },\n            {\n              \"id\": \"it_2238\",\n              \"name\": \"Content creation\"\n            },\n            {\n              \"id\": \"it_2117\",\n              \"name\": \"E-sports\"\n            },\n            {\n              \"id\": \"it_2220\",\n              \"name\": \"Bicycle racing\"\n            },\n            {\n              \"id\": \"it_2221\",\n              \"name\": \"Binge-watching TV series\"\n            },\n            {\n              \"id\": \"it_1011\",\n              \"name\": \"Songwriter\"\n            },\n            {\n              \"id\": \"it_2224\",\n              \"name\": \"Bodycombat\"\n            },\n            {\n              \"id\": \"it_1014\",\n              \"name\": \"Tattoos\"\n            },\n            {\n              \"id\": \"it_2346\",\n              \"name\": \"Painting\"\n            },\n            {\n              \"id\": \"it_2225\",\n              \"name\": \"Bodyjam\"\n            },\n            {\n              \"id\": \"it_2343\",\n              \"name\": \"Paddle boarding\"\n            },\n            {\n              \"id\": \"it_2344\",\n              \"name\": \"Padel\"\n            },\n            {\n              \"id\": \"it_2223\",\n              \"name\": \"Blackpink\"\n            },\n            {\n              \"id\": \"it_1013\",\n              \"name\": \"Surfing\"\n            },\n            {\n              \"id\": \"it_2228\",\n              \"name\": \"Bowling\"\n            },\n            {\n              \"id\": \"it_2107\",\n              \"name\": \"Grime\"\n            },\n            {\n              \"id\": \"it_2108\",\n              \"name\": \"’90s Britpop\"\n            },\n            {\n              \"id\": \"it_2226\",\n              \"name\": \"Bodypump\"\n            },\n            {\n              \"id\": \"it_2106\",\n              \"name\": \"Beach bars\"\n            },\n            {\n              \"id\": \"it_2227\",\n              \"name\": \"Bodystep\"\n            },\n            {\n              \"id\": \"it_2348\",\n              \"name\": \"Paragliding\"\n            },\n            {\n              \"id\": \"it_2109\",\n              \"name\": \"Upcycling\"\n            },\n            {\n              \"id\": \"it_2253\",\n              \"name\": \"Equality\"\n            },\n            {\n              \"id\": \"it_2011\",\n              \"name\": \"Astrology\"\n            },\n            {\n              \"id\": \"it_2133\",\n              \"name\": \"Motorcycles\"\n            },\n            {\n              \"id\": \"it_2254\",\n              \"name\": \"Equestrian\"\n            },\n            {\n              \"id\": \"it_2251\",\n              \"name\": \"Entrepreneurship\"\n            },\n            {\n              \"id\": \"it_2372\",\n              \"name\": \"Sake\"\n            },\n            {\n              \"id\": \"it_2131\",\n              \"name\": \"BTS\"\n            },\n            {\n              \"id\": \"it_2010\",\n              \"name\": \"Cooking\"\n            },\n            {\n              \"id\": \"it_2252\",\n              \"name\": \"Environmental protection\"\n            },\n            {\n              \"id\": \"it_2257\",\n              \"name\": \"Fencing\"\n            },\n            {\n              \"id\": \"it_2015\",\n              \"name\": \"Football\"\n            },\n            {\n              \"id\": \"it_2378\",\n              \"name\": \"Saxophonist\"\n            },\n            {\n              \"id\": \"it_2379\",\n              \"name\": \"Sci-fi\"\n            },\n            {\n              \"id\": \"it_2016\",\n              \"name\": \"Dancing\"\n            },\n            {\n              \"id\": \"it_2258\",\n              \"name\": \"Film festivals\"\n            },\n            {\n              \"id\": \"it_2013\",\n              \"name\": \"Gardening\"\n            },\n            {\n              \"id\": \"it_2135\",\n              \"name\": \"Amateur cook\"\n            },\n            {\n              \"id\": \"it_2256\",\n              \"name\": \"Exchange programmes\"\n            },\n            {\n              \"id\": \"it_2377\",\n              \"name\": \"Sauna\"\n            },\n            {\n              \"id\": \"it_2014\",\n              \"name\": \"Art\"\n            },\n            {\n              \"id\": \"it_2019\",\n              \"name\": \"Politics\"\n            },\n            {\n              \"id\": \"it_2259\",\n              \"name\": \"Flamenco\"\n            },\n            {\n              \"id\": \"it_2017\",\n              \"name\": \"Museum\"\n            },\n            {\n              \"id\": \"it_2018\",\n              \"name\": \"Activism\"\n            },\n            {\n              \"id\": \"it_2242\",\n              \"name\": \"DAOs\"\n            },\n            {\n              \"id\": \"it_2363\",\n              \"name\": \"Real estate\"\n            },\n            {\n              \"id\": \"it_2121\",\n              \"name\": \"Podcasts\"\n            },\n            {\n              \"id\": \"it_2243\",\n              \"name\": \"Disability rights\"\n            },\n            {\n              \"id\": \"it_2362\",\n              \"name\": \"Rave\"\n            },\n            {\n              \"id\": \"it_2120\",\n              \"name\": \"Pimms\"\n            },\n            {\n              \"id\": \"it_2246\",\n              \"name\": \"Drive-in cinema\"\n            },\n            {\n              \"id\": \"it_2367\",\n              \"name\": \"Rock climbing\"\n            },\n            {\n              \"id\": \"it_2125\",\n              \"name\": \"BBQ\"\n            },\n            {\n              \"id\": \"it_2004\",\n              \"name\": \"Craft beer\"\n            },\n            {\n              \"id\": \"it_2126\",\n              \"name\": \"Iced tea\"\n            },\n            {\n              \"id\": \"it_2247\",\n              \"name\": \"Drummer\"\n            },\n            {\n              \"id\": \"it_2005\",\n              \"name\": \"Tea\"\n            },\n            {\n              \"id\": \"it_2002\",\n              \"name\": \"Board games\"\n            },\n            {\n              \"id\": \"it_2365\",\n              \"name\": \"Roblox\"\n            },\n            {\n              \"id\": \"it_2123\",\n              \"name\": \"Pubs\"\n            },\n            {\n              \"id\": \"it_2366\",\n              \"name\": \"Rock\"\n            },\n            {\n              \"id\": \"it_2124\",\n              \"name\": \"Tango\"\n            },\n            {\n              \"id\": \"it_2245\",\n              \"name\": \"Drawing\"\n            },\n            {\n              \"id\": \"it_2003\",\n              \"name\": \"Trivia\"\n            },\n            {\n              \"id\": \"it_2129\",\n              \"name\": \"Pho\"\n            },\n            {\n              \"id\": \"it_2008\",\n              \"name\": \"Volunteering\"\n            },\n            {\n              \"id\": \"it_2009\",\n              \"name\": \"Environmentalism\"\n            },\n            {\n              \"id\": \"it_2369\",\n              \"name\": \"Rollerskating\"\n            },\n            {\n              \"id\": \"it_2006\",\n              \"name\": \"Wine\"\n            },\n            {\n              \"id\": \"it_2248\",\n              \"name\": \"Dungeons & Dragons\"\n            },\n            {\n              \"id\": \"it_2007\",\n              \"name\": \"Vlogging\"\n            },\n            {\n              \"id\": \"it_2249\",\n              \"name\": \"Electronic music\"\n            },\n            {\n              \"id\": \"it_2360\",\n              \"name\": \"Ramen\"\n            },\n            {\n              \"id\": \"it_2430\",\n              \"name\": \"Weightlifting\"\n            },\n            {\n              \"id\": \"it_2312\",\n              \"name\": \"Live music\"\n            },\n            {\n              \"id\": \"it_2433\",\n              \"name\": \"Writing\"\n            },\n            {\n              \"id\": \"it_2434\",\n              \"name\": \"Xbox\"\n            },\n            {\n              \"id\": \"it_2431\",\n              \"name\": \"World peace\"\n            },\n            {\n              \"id\": \"it_2432\",\n              \"name\": \"Wrestling\"\n            },\n            {\n              \"id\": \"it_2311\",\n              \"name\": \"Literature\"\n            },\n            {\n              \"id\": \"it_2316\",\n              \"name\": \"Manga\"\n            },\n            {\n              \"id\": \"it_2437\",\n              \"name\": \"Pride\"\n            },\n            {\n              \"id\": \"it_2317\",\n              \"name\": \"Marathon\"\n            },\n            {\n              \"id\": \"it_2314\",\n              \"name\": \"Make-up\"\n            },\n            {\n              \"id\": \"it_2435\",\n              \"name\": \"Youth empowerment\"\n            },\n            {\n              \"id\": \"it_2436\",\n              \"name\": \"YouTube\"\n            },\n            {\n              \"id\": \"it_2318\",\n              \"name\": \"Martial arts\"\n            },\n            {\n              \"id\": \"it_2319\",\n              \"name\": \"Marvel\"\n            },\n            {\n              \"id\": \"it_5020\",\n              \"name\": \"Luge\"\n            },\n            {\n              \"id\": \"it_5021\",\n              \"name\": \"Ice hockey\"\n            },\n            {\n              \"id\": \"it_5016\",\n              \"name\": \"Taekwondo\"\n            },\n            {\n              \"id\": \"it_5017\",\n              \"name\": \"Trampolining\"\n            },\n            {\n              \"id\": \"it_5018\",\n              \"name\": \"Water polo\"\n            },\n            {\n              \"id\": \"it_5012\",\n              \"name\": \"Rhythmic gymnastics\"\n            },\n            {\n              \"id\": \"it_2422\",\n              \"name\": \"Vegan cooking\"\n            },\n            {\n              \"id\": \"it_5013\",\n              \"name\": \"Rowing\"\n            },\n            {\n              \"id\": \"it_2423\",\n              \"name\": \"Vermouth\"\n            },\n            {\n              \"id\": \"it_2302\",\n              \"name\": \"Korean food\"\n            },\n            {\n              \"id\": \"it_5014\",\n              \"name\": \"Sports shooting\"\n            },\n            {\n              \"id\": \"it_2420\",\n              \"name\": \"Twitter\"\n            },\n            {\n              \"id\": \"it_5015\",\n              \"name\": \"Squash\"\n            },\n            {\n              \"id\": \"it_2426\",\n              \"name\": \"Volleyball\"\n            },\n            {\n              \"id\": \"it_2427\",\n              \"name\": \"Walking tours\"\n            },\n            {\n              \"id\": \"it_2424\",\n              \"name\": \"Vinyasa\"\n            },\n            {\n              \"id\": \"it_2425\",\n              \"name\": \"Virtual reality\"\n            },\n            {\n              \"id\": \"it_2309\",\n              \"name\": \"League of Legends\"\n            },\n            {\n              \"id\": \"it_5010\",\n              \"name\": \"Karate\"\n            },\n            {\n              \"id\": \"it_5011\",\n              \"name\": \"Lacrosse\"\n            },\n            {\n              \"id\": \"it_2334\",\n              \"name\": \"NFTs\"\n            },\n            {\n              \"id\": \"it_2213\",\n              \"name\": \"Pub crawls\"\n            },\n            {\n              \"id\": \"it_2335\",\n              \"name\": \"Nintendo\"\n            },\n            {\n              \"id\": \"it_2214\",\n              \"name\": \"Baseball\"\n            },\n            {\n              \"id\": \"it_1001\",\n              \"name\": \"Parties\"\n            },\n            {\n              \"id\": \"it_2211\",\n              \"name\": \"Ballet\"\n            },\n            {\n              \"id\": \"it_2212\",\n              \"name\": \"Bands\"\n            },\n            {\n              \"id\": \"it_2338\",\n              \"name\": \"Online games\"\n            },\n            {\n              \"id\": \"it_2217\",\n              \"name\": \"Battle Ground\"\n            },\n            {\n              \"id\": \"it_2218\",\n              \"name\": \"Beach tennis\"\n            },\n            {\n              \"id\": \"it_99\",\n              \"name\": \"Nightlife\"\n            },\n            {\n              \"id\": \"it_2339\",\n              \"name\": \"Online shopping\"\n            },\n            {\n              \"id\": \"it_1005\",\n              \"name\": \"Sailing\"\n            },\n            {\n              \"id\": \"it_2215\",\n              \"name\": \"Bassist\"\n            },\n            {\n              \"id\": \"it_2337\",\n              \"name\": \"Online broker\"\n            },\n            {\n              \"id\": \"it_94\",\n              \"name\": \"Military\"\n            },\n            {\n              \"id\": \"it_2320\",\n              \"name\": \"Memes\"\n            },\n            {\n              \"id\": \"it_2202\",\n              \"name\": \"Among Us\"\n            },\n            {\n              \"id\": \"it_2323\",\n              \"name\": \"Motorbike racing\"\n            },\n            {\n              \"id\": \"it_5155\",\n              \"name\": \"Muay Thai\"\n            },\n            {\n              \"id\": \"it_2324\",\n              \"name\": \"Motorcycling\"\n            },\n            {\n              \"id\": \"it_2321\",\n              \"name\": \"Metaverse\"\n            },\n            {\n              \"id\": \"it_2322\",\n              \"name\": \"Mindfulness\"\n            },\n            {\n              \"id\": \"it_2201\",\n              \"name\": \"Acapella\"\n            },\n            {\n              \"id\": \"it_2327\",\n              \"name\": \"Playing a musical instrument\"\n            },\n            {\n              \"id\": \"it_2206\",\n              \"name\": \"Art galleries\"\n            },\n            {\n              \"id\": \"it_2328\",\n              \"name\": \"Writing musicals\"\n            },\n            {\n              \"id\": \"it_88\",\n              \"name\": \"Hiking\"\n            },\n            {\n              \"id\": \"it_2207\",\n              \"name\": \"Artistic gymnastics\"\n            },\n            {\n              \"id\": \"it_2325\",\n              \"name\": \"Mountains\"\n            },\n            {\n              \"id\": \"it_2205\",\n              \"name\": \"Archery\"\n            },\n            {\n              \"id\": \"it_2208\",\n              \"name\": \"Atari\"\n            },\n            {\n              \"id\": \"it_2209\",\n              \"name\": \"Backpacking\"\n            },\n            {\n              \"id\": \"it_86\",\n              \"name\": \"Fishing\"\n            },\n            {\n              \"id\": \"it_2075\",\n              \"name\": \"Clubbing\"\n            },\n            {\n              \"id\": \"it_2079\",\n              \"name\": \"Street food\"\n            },\n            {\n              \"id\": \"it_78\",\n              \"name\": \"Crossfit\"\n            },\n            {\n              \"id\": \"it_76\",\n              \"name\": \"Concerts\"\n            },\n            {\n              \"id\": \"it_75\",\n              \"name\": \"Climbing\"\n            },\n            {\n              \"id\": \"it_70\",\n              \"name\": \"Baking\"\n            },\n            {\n              \"id\": \"it_72\",\n              \"name\": \"Camping\"\n            },\n            {\n              \"id\": \"it_71\",\n              \"name\": \"Blogging\"\n            },\n            {\n              \"id\": \"it_2070\",\n              \"name\": \"Collecting\"\n            },\n            {\n              \"id\": \"it_2072\",\n              \"name\": \"Cars\"\n            },\n            {\n              \"id\": \"it_2066\",\n              \"name\": \"Start-ups\"\n            },\n            {\n              \"id\": \"it_2067\",\n              \"name\": \"Boba tea\"\n            },\n            {\n              \"id\": \"it_2064\",\n              \"name\": \"High-school baseketball league (TW)\"\n            },\n            {\n              \"id\": \"it_2069\",\n              \"name\": \"Badminton\"\n            },\n            {\n              \"id\": \"it_66\",\n              \"name\": \"Active lifestyle\"\n            },\n            {\n              \"id\": \"it_63\",\n              \"name\": \"Fashion\"\n            },\n            {\n              \"id\": \"it_62\",\n              \"name\": \"Anime\"\n            },\n            {\n              \"id\": \"it_2062\",\n              \"name\": \"NBA\"\n            },\n            {\n              \"id\": \"it_2063\",\n              \"name\": \"MLB\"\n            },\n            {\n              \"id\": \"it_2099\",\n              \"name\": \"Funk music\"\n            },\n            {\n              \"id\": \"it_5006\",\n              \"name\": \"Diving\"\n            },\n            {\n              \"id\": \"it_2097\",\n              \"name\": \"Caipirinha\"\n            },\n            {\n              \"id\": \"it_5007\",\n              \"name\": \"American flag football\"\n            },\n            {\n              \"id\": \"it_5008\",\n              \"name\": \"Handball\"\n            },\n            {\n              \"id\": \"it_5001\",\n              \"name\": \"Artistic swimming\"\n            },\n            {\n              \"id\": \"it_5002\",\n              \"name\": \"Athletics\"\n            },\n            {\n              \"id\": \"it_59\",\n              \"name\": \"Indoor activities\"\n            },\n            {\n              \"id\": \"it_5003\",\n              \"name\": \"Softball\"\n            },\n            {\n              \"id\": \"it_5004\",\n              \"name\": \"Beach volleyball\"\n            },\n            {\n              \"id\": \"it_2410\",\n              \"name\": \"Tempeh\"\n            },\n            {\n              \"id\": \"it_56\",\n              \"name\": \"DIY\"\n            },\n            {\n              \"id\": \"it_2416\",\n              \"name\": \"Town festivities\"\n            },\n            {\n              \"id\": \"it_55\",\n              \"name\": \"Cycling\"\n            },\n            {\n              \"id\": \"it_58\",\n              \"name\": \"Outdoors\"\n            },\n            {\n              \"id\": \"it_2414\",\n              \"name\": \"TikTok\"\n            },\n            {\n              \"id\": \"it_57\",\n              \"name\": \"Picnicking\"\n            },\n            {\n              \"id\": \"it_2419\",\n              \"name\": \"Twitch\"\n            },\n            {\n              \"id\": \"it_5009\",\n              \"name\": \"Judo\"\n            },\n            {\n              \"id\": \"it_51\",\n              \"name\": \"Comedy\"\n            },\n            {\n              \"id\": \"it_2417\",\n              \"name\": \"Trap music\"\n            },\n            {\n              \"id\": \"it_54\",\n              \"name\": \"Music\"\n            },\n            {\n              \"id\": \"it_2418\",\n              \"name\": \"Triathlon\"\n            },\n            {\n              \"id\": \"it_53\",\n              \"name\": \"Netflix\"\n            },\n            {\n              \"id\": \"it_50\",\n              \"name\": \"Disney\"\n            },\n            {\n              \"id\": \"it_2090\",\n              \"name\": \"Rugby\"\n            },\n            {\n              \"id\": \"it_2095\",\n              \"name\": \"Açaí\"\n            },\n            {\n              \"id\": \"it_2093\",\n              \"name\": \"Samba\"\n            },\n            {\n              \"id\": \"it_2094\",\n              \"name\": \"Tarot\"\n            },\n            {\n              \"id\": \"it_2400\",\n              \"name\": \"Stock exchange\"\n            },\n            {\n              \"id\": \"it_2401\",\n              \"name\": \"Stocks\"\n            },\n            {\n              \"id\": \"it_48\",\n              \"name\": \"Swimming\"\n            },\n            {\n              \"id\": \"it_2404\",\n              \"name\": \"Table tennis\"\n            },\n            {\n              \"id\": \"it_41\",\n              \"name\": \"Killing time\"\n            },\n            {\n              \"id\": \"it_43\",\n              \"name\": \"Working out\"\n            },\n            {\n              \"id\": \"it_42\",\n              \"name\": \"Yoga\"\n            },\n            {\n              \"id\": \"it_2080\",\n              \"name\": \"Horror films\"\n            },\n            {\n              \"id\": \"it_2081\",\n              \"name\": \"Boxing\"\n            },\n            {\n              \"id\": \"it_2082\",\n              \"name\": \"Chilling at a bar\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/language@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/language@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/language@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/language@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"minSelections\": 3,\n          \"maxSelections\": 5,\n          \"backgroundText\": \"Add interests\",\n          \"searchBackgroundText\": \"Search interests\",\n          \"sectionId\": 2,\n          \"sectionName\": \"Interests\",\n          \"matchGroupKey\": \"languages\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": false\n        }\n      ]", new System.Text.Json.JsonDocumentOptions()));

            migrationBuilder.UpdateData(
                table: "AvailableDescriptors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Descriptors",
                value: System.Text.Json.JsonDocument.Parse("[\n        {\n          \"id\": \"de_29\",\n          \"name\": \"Looking for\",\n          \"prompt\": \"What are you looking for?\",\n          \"type\": \"choice_selector_v1\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Long-term partner\",\n              \"style\": \"purple\",\n              \"emoji\": \"💘\",\n              \"iconUrls\": [\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_cupid@1x.png\",\n                  \"quality\": \"1x\",\n                  \"width\": 50,\n                  \"height\": 50\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_cupid@2x.png\",\n                  \"quality\": \"2x\",\n                  \"width\": 100,\n                  \"height\": 100\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_cupid@3x.png\",\n                  \"quality\": \"3x\",\n                  \"width\": 150,\n                  \"height\": 150\n                }\n              ],\n              \"matchGroupKey\": \"Serious\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Long-term, but short-term OK\",\n              \"style\": \"pink\",\n              \"emoji\": \"😍\",\n              \"iconUrls\": [\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_heart_eyes@1x.png\",\n                  \"quality\": \"1x\",\n                  \"width\": 50,\n                  \"height\": 50\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_heart_eyes@2x.png\",\n                  \"quality\": \"2x\",\n                  \"width\": 100,\n                  \"height\": 100\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_heart_eyes@3x.png\",\n                  \"quality\": \"3x\",\n                  \"width\": 150,\n                  \"height\": 150\n                }\n              ]\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Short-term, but long-term OK\",\n              \"style\": \"yellow\",\n              \"emoji\": \"🥂\",\n              \"iconUrls\": [\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_clinking_glasses@1x.png\",\n                  \"quality\": \"1x\",\n                  \"width\": 50,\n                  \"height\": 50\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_clinking_glasses@2x.png\",\n                  \"quality\": \"2x\",\n                  \"width\": 100,\n                  \"height\": 100\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_clinking_glasses@3x.png\",\n                  \"quality\": \"3x\",\n                  \"width\": 150,\n                  \"height\": 150\n                }\n              ]\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"Short-term fun\",\n              \"style\": \"green\",\n              \"emoji\": \"🎉\",\n              \"iconUrls\": [\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_tada@1x.png\",\n                  \"quality\": \"1x\",\n                  \"width\": 50,\n                  \"height\": 50\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_tada@2x.png\",\n                  \"quality\": \"2x\",\n                  \"width\": 100,\n                  \"height\": 100\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_tada@3x.png\",\n                  \"quality\": \"3x\",\n                  \"width\": 150,\n                  \"height\": 150\n                }\n              ],\n              \"matchGroupKey\": \"Casual\"\n            },\n            {\n              \"id\": \"5\",\n              \"name\": \"New friends\",\n              \"style\": \"teal\",\n              \"emoji\": \"👋\",\n              \"iconUrls\": [\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_wave@1x.png\",\n                  \"quality\": \"1x\",\n                  \"width\": 50,\n                  \"height\": 50\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_wave@2x.png\",\n                  \"quality\": \"2x\",\n                  \"width\": 100,\n                  \"height\": 100\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_wave@3x.png\",\n                  \"quality\": \"3x\",\n                  \"width\": 150,\n                  \"height\": 150\n                }\n              ],\n              \"matchGroupKey\": \"Friends\"\n            },\n            {\n              \"id\": \"6\",\n              \"name\": \"Still figuring it out\",\n              \"style\": \"blue\",\n              \"emoji\": \"🤔\",\n              \"iconUrls\": [\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_thinking_face@1x.png\",\n                  \"quality\": \"1x\",\n                  \"width\": 50,\n                  \"height\": 50\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_thinking_face@2x.png\",\n                  \"quality\": \"2x\",\n                  \"width\": 100,\n                  \"height\": 100\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_thinking_face@3x.png\",\n                  \"quality\": \"3x\",\n                  \"width\": 150,\n                  \"height\": 150\n                }\n              ],\n              \"matchGroupKey\": \"DontKnow\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/looking_for@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/looking_for@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/looking_for@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/looking_for@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"subPrompt\": \"All good if it changes. There’s something for everyone.\",\n          \"sectionId\": 3,\n          \"sectionName\": \"Relationship Goals\",\n          \"matchGroupKey\": \"intent\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        }\n      ]", new System.Text.Json.JsonDocumentOptions()));

            migrationBuilder.UpdateData(
                table: "AvailableDescriptors",
                keyColumn: "Id",
                keyValue: 4,
                column: "Descriptors",
                value: System.Text.Json.JsonDocument.Parse("[\n        {\n          \"id\": \"de_37\",\n          \"type\": \"multiSelectionSet\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Afrikaans\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Albanian\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Amharic\"\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"Arabic\",\n              \"matchGroupKey\": \"Arabic\"\n            },\n            {\n              \"id\": \"5\",\n              \"name\": \"Armenian\",\n              \"matchGroupKey\": \"Armenian\"\n            },\n            {\n              \"id\": \"133\",\n              \"name\": \"ASL\"\n            },\n            {\n              \"id\": \"6\",\n              \"name\": \"Assamese\"\n            },\n            {\n              \"id\": \"7\",\n              \"name\": \"Aymara\"\n            },\n            {\n              \"id\": \"8\",\n              \"name\": \"Azerbaijani\"\n            },\n            {\n              \"id\": \"9\",\n              \"name\": \"Bambara\"\n            },\n            {\n              \"id\": \"10\",\n              \"name\": \"Basque\"\n            },\n            {\n              \"id\": \"11\",\n              \"name\": \"Belarusian\"\n            },\n            {\n              \"id\": \"12\",\n              \"name\": \"Bengali\",\n              \"matchGroupKey\": \"Bengali\"\n            },\n            {\n              \"id\": \"13\",\n              \"name\": \"Bhojpuri\"\n            },\n            {\n              \"id\": \"14\",\n              \"name\": \"Bosnian\"\n            },\n            {\n              \"id\": \"134\",\n              \"name\": \"Breton\"\n            },\n            {\n              \"id\": \"15\",\n              \"name\": \"Bulgarian\",\n              \"matchGroupKey\": \"Bulgarian\"\n            },\n            {\n              \"id\": \"16\",\n              \"name\": \"Burmese\"\n            },\n            {\n              \"id\": \"17\",\n              \"name\": \"Cantonese\",\n              \"matchGroupKey\": \"Cantonese\"\n            },\n            {\n              \"id\": \"18\",\n              \"name\": \"Catalan\"\n            },\n            {\n              \"id\": \"19\",\n              \"name\": \"Cebuano\"\n            },\n            {\n              \"id\": \"20\",\n              \"name\": \"Chichewa\"\n            },\n            {\n              \"id\": \"21\",\n              \"name\": \"Corsican\"\n            },\n            {\n              \"id\": \"22\",\n              \"name\": \"Croatian\"\n            },\n            {\n              \"id\": \"23\",\n              \"name\": \"Czech\",\n              \"matchGroupKey\": \"Czech\"\n            },\n            {\n              \"id\": \"24\",\n              \"name\": \"Danish\",\n              \"matchGroupKey\": \"Danish\"\n            },\n            {\n              \"id\": \"25\",\n              \"name\": \"Dhivehi\"\n            },\n            {\n              \"id\": \"26\",\n              \"name\": \"Dogri\"\n            },\n            {\n              \"id\": \"27\",\n              \"name\": \"Dutch\",\n              \"matchGroupKey\": \"Dutch\"\n            },\n            {\n              \"id\": \"28\",\n              \"name\": \"English\",\n              \"matchGroupKey\": \"English\"\n            },\n            {\n              \"id\": \"29\",\n              \"name\": \"Esperanto\"\n            },\n            {\n              \"id\": \"30\",\n              \"name\": \"Estonian\"\n            },\n            {\n              \"id\": \"31\",\n              \"name\": \"Ewe\"\n            },\n            {\n              \"id\": \"32\",\n              \"name\": \"Filipino\"\n            },\n            {\n              \"id\": \"33\",\n              \"name\": \"Finnish\",\n              \"matchGroupKey\": \"Finnish\"\n            },\n            {\n              \"id\": \"34\",\n              \"name\": \"French\",\n              \"matchGroupKey\": \"French\"\n            },\n            {\n              \"id\": \"35\",\n              \"name\": \"Frisian\"\n            },\n            {\n              \"id\": \"36\",\n              \"name\": \"Galician\"\n            },\n            {\n              \"id\": \"37\",\n              \"name\": \"Georgian\"\n            },\n            {\n              \"id\": \"38\",\n              \"name\": \"German\",\n              \"matchGroupKey\": \"German\"\n            },\n            {\n              \"id\": \"39\",\n              \"name\": \"Greek\",\n              \"matchGroupKey\": \"Greek\"\n            },\n            {\n              \"id\": \"40\",\n              \"name\": \"Guaraní\"\n            },\n            {\n              \"id\": \"41\",\n              \"name\": \"Gujarati\",\n              \"matchGroupKey\": \"Gujarati\"\n            },\n            {\n              \"id\": \"42\",\n              \"name\": \"Haitian Creole\"\n            },\n            {\n              \"id\": \"43\",\n              \"name\": \"Hausa\"\n            },\n            {\n              \"id\": \"44\",\n              \"name\": \"Hawaiian\"\n            },\n            {\n              \"id\": \"45\",\n              \"name\": \"Hebrew\",\n              \"matchGroupKey\": \"Hebrew\"\n            },\n            {\n              \"id\": \"46\",\n              \"name\": \"Hindi\",\n              \"matchGroupKey\": \"Hindi\"\n            },\n            {\n              \"id\": \"47\",\n              \"name\": \"Hmong\"\n            },\n            {\n              \"id\": \"48\",\n              \"name\": \"Hungarian\",\n              \"matchGroupKey\": \"Hungarian\"\n            },\n            {\n              \"id\": \"49\",\n              \"name\": \"Icelandic\"\n            },\n            {\n              \"id\": \"50\",\n              \"name\": \"Igbo\"\n            },\n            {\n              \"id\": \"51\",\n              \"name\": \"Ilocano\"\n            },\n            {\n              \"id\": \"52\",\n              \"name\": \"Indonesian\",\n              \"matchGroupKey\": \"Indonesian\"\n            },\n            {\n              \"id\": \"53\",\n              \"name\": \"Irish\",\n              \"matchGroupKey\": \"Irish\"\n            },\n            {\n              \"id\": \"54\",\n              \"name\": \"Italian\",\n              \"matchGroupKey\": \"Italian\"\n            },\n            {\n              \"id\": \"55\",\n              \"name\": \"Japanese\",\n              \"matchGroupKey\": \"Japanese\"\n            },\n            {\n              \"id\": \"56\",\n              \"name\": \"Javanese\"\n            },\n            {\n              \"id\": \"57\",\n              \"name\": \"Kannada\"\n            },\n            {\n              \"id\": \"58\",\n              \"name\": \"Kazakh\"\n            },\n            {\n              \"id\": \"59\",\n              \"name\": \"Khmer\",\n              \"matchGroupKey\": \"Khmer\"\n            },\n            {\n              \"id\": \"60\",\n              \"name\": \"Kinyarwanda\"\n            },\n            {\n              \"id\": \"61\",\n              \"name\": \"Konkani\"\n            },\n            {\n              \"id\": \"62\",\n              \"name\": \"Korean\",\n              \"matchGroupKey\": \"Korean\"\n            },\n            {\n              \"id\": \"63\",\n              \"name\": \"Krio\"\n            },\n            {\n              \"id\": \"64\",\n              \"name\": \"Kurdish\"\n            },\n            {\n              \"id\": \"65\",\n              \"name\": \"Kyrgyz\"\n            },\n            {\n              \"id\": \"66\",\n              \"name\": \"Lao\"\n            },\n            {\n              \"id\": \"67\",\n              \"name\": \"Latin\"\n            },\n            {\n              \"id\": \"68\",\n              \"name\": \"Latvian\",\n              \"matchGroupKey\": \"Latvian\"\n            },\n            {\n              \"id\": \"69\",\n              \"name\": \"Lingala\"\n            },\n            {\n              \"id\": \"70\",\n              \"name\": \"Lithuanian\",\n              \"matchGroupKey\": \"Lithuanian\"\n            },\n            {\n              \"id\": \"71\",\n              \"name\": \"Luganda\"\n            },\n            {\n              \"id\": \"72\",\n              \"name\": \"Luxembourgish\"\n            },\n            {\n              \"id\": \"73\",\n              \"name\": \"Macedonian\"\n            },\n            {\n              \"id\": \"74\",\n              \"name\": \"Maithili\"\n            },\n            {\n              \"id\": \"75\",\n              \"name\": \"Malagasy\"\n            },\n            {\n              \"id\": \"76\",\n              \"name\": \"Malay\",\n              \"matchGroupKey\": \"Malay\"\n            },\n            {\n              \"id\": \"77\",\n              \"name\": \"Malayalam\"\n            },\n            {\n              \"id\": \"78\",\n              \"name\": \"Maltese\"\n            },\n            {\n              \"id\": \"79\",\n              \"name\": \"Mandarin Chinese\",\n              \"matchGroupKey\": \"Chinese\"\n            },\n            {\n              \"id\": \"80\",\n              \"name\": \"Manipuri\"\n            },\n            {\n              \"id\": \"81\",\n              \"name\": \"Maori\"\n            },\n            {\n              \"id\": \"82\",\n              \"name\": \"Marathi\"\n            },\n            {\n              \"id\": \"83\",\n              \"name\": \"Mizo\"\n            },\n            {\n              \"id\": \"84\",\n              \"name\": \"Mongolian\"\n            },\n            {\n              \"id\": \"85\",\n              \"name\": \"Nepali\"\n            },\n            {\n              \"id\": \"86\",\n              \"name\": \"Norwegian\",\n              \"matchGroupKey\": \"Norwegian\"\n            },\n            {\n              \"id\": \"87\",\n              \"name\": \"Odia\"\n            },\n            {\n              \"id\": \"88\",\n              \"name\": \"Oromo\"\n            },\n            {\n              \"id\": \"89\",\n              \"name\": \"Pashto\"\n            },\n            {\n              \"id\": \"90\",\n              \"name\": \"Persian\",\n              \"matchGroupKey\": \"Persian\"\n            },\n            {\n              \"id\": \"91\",\n              \"name\": \"Polish\",\n              \"matchGroupKey\": \"Polish\"\n            },\n            {\n              \"id\": \"92\",\n              \"name\": \"Portuguese\",\n              \"matchGroupKey\": \"Portuguese\"\n            },\n            {\n              \"id\": \"93\",\n              \"name\": \"Punjabi\",\n              \"matchGroupKey\": \"Punjabi\"\n            },\n            {\n              \"id\": \"94\",\n              \"name\": \"Quechua\"\n            },\n            {\n              \"id\": \"95\",\n              \"name\": \"Romanian\",\n              \"matchGroupKey\": \"Romanian\"\n            },\n            {\n              \"id\": \"96\",\n              \"name\": \"Russian\",\n              \"matchGroupKey\": \"Russian\"\n            },\n            {\n              \"id\": \"97\",\n              \"name\": \"Samoan\"\n            },\n            {\n              \"id\": \"98\",\n              \"name\": \"Sanskrit\"\n            },\n            {\n              \"id\": \"99\",\n              \"name\": \"Scots Gaelic\"\n            },\n            {\n              \"id\": \"100\",\n              \"name\": \"Sepedi\"\n            },\n            {\n              \"id\": \"101\",\n              \"name\": \"Serbian\"\n            },\n            {\n              \"id\": \"102\",\n              \"name\": \"Sesotho\"\n            },\n            {\n              \"id\": \"103\",\n              \"name\": \"Shona\"\n            },\n            {\n              \"id\": \"104\",\n              \"name\": \"Sindhi\"\n            },\n            {\n              \"id\": \"105\",\n              \"name\": \"Sinhala\"\n            },\n            {\n              \"id\": \"106\",\n              \"name\": \"Slovak\",\n              \"matchGroupKey\": \"Slovak\"\n            },\n            {\n              \"id\": \"107\",\n              \"name\": \"Slovenian\",\n              \"matchGroupKey\": \"Slovenian\"\n            },\n            {\n              \"id\": \"108\",\n              \"name\": \"Somali\"\n            },\n            {\n              \"id\": \"109\",\n              \"name\": \"Spanish\",\n              \"matchGroupKey\": \"Spanish\"\n            },\n            {\n              \"id\": \"110\",\n              \"name\": \"Sundanese\"\n            },\n            {\n              \"id\": \"111\",\n              \"name\": \"Swahili\",\n              \"matchGroupKey\": \"Swahili\"\n            },\n            {\n              \"id\": \"112\",\n              \"name\": \"Swedish\",\n              \"matchGroupKey\": \"Swedish\"\n            },\n            {\n              \"id\": \"113\",\n              \"name\": \"Tajik\"\n            },\n            {\n              \"id\": \"114\",\n              \"name\": \"Tamil\",\n              \"matchGroupKey\": \"Tamil\"\n            },\n            {\n              \"id\": \"115\",\n              \"name\": \"Tatar\"\n            },\n            {\n              \"id\": \"116\",\n              \"name\": \"Telugu\"\n            },\n            {\n              \"id\": \"117\",\n              \"name\": \"Thai\",\n              \"matchGroupKey\": \"Thai\"\n            },\n            {\n              \"id\": \"118\",\n              \"name\": \"Tigrinya\"\n            },\n            {\n              \"id\": \"119\",\n              \"name\": \"Tsonga\"\n            },\n            {\n              \"id\": \"120\",\n              \"name\": \"Turkish\",\n              \"matchGroupKey\": \"Turkish\"\n            },\n            {\n              \"id\": \"121\",\n              \"name\": \"Turkmen\"\n            },\n            {\n              \"id\": \"122\",\n              \"name\": \"Twi\"\n            },\n            {\n              \"id\": \"123\",\n              \"name\": \"Ukrainian\",\n              \"matchGroupKey\": \"Ukranian\"\n            },\n            {\n              \"id\": \"124\",\n              \"name\": \"Urdu\",\n              \"matchGroupKey\": \"Urdu\"\n            },\n            {\n              \"id\": \"125\",\n              \"name\": \"Uyghur\"\n            },\n            {\n              \"id\": \"126\",\n              \"name\": \"Uzbek\"\n            },\n            {\n              \"id\": \"127\",\n              \"name\": \"Vietnamese\",\n              \"matchGroupKey\": \"Vietnamese\"\n            },\n            {\n              \"id\": \"128\",\n              \"name\": \"Welsh\"\n            },\n            {\n              \"id\": \"129\",\n              \"name\": \"Xhosa\"\n            },\n            {\n              \"id\": \"130\",\n              \"name\": \"Yiddish\"\n            },\n            {\n              \"id\": \"131\",\n              \"name\": \"Yoruba\"\n            },\n            {\n              \"id\": \"132\",\n              \"name\": \"Zulu\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/language@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/language@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/language@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/language@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"minSelections\": 1,\n          \"maxSelections\": 5,\n          \"backgroundText\": \"Add languages\",\n          \"searchBackgroundText\": \"Search languages\",\n          \"sectionId\": 4,\n          \"sectionName\": \"Languages I know\",\n          \"matchGroupKey\": \"languages\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": false\n        }\n      ]", new System.Text.Json.JsonDocumentOptions()));

            migrationBuilder.UpdateData(
                table: "AvailableDescriptors",
                keyColumn: "Id",
                keyValue: 5,
                column: "Descriptors",
                value: System.Text.Json.JsonDocument.Parse("[\n        {\n          \"id\": \"de_1\",\n          \"name\": \"Zodiac\",\n          \"prompt\": \"What’s your star sign?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Capricorn\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Aquarius\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Pisces\"\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"Aries\"\n            },\n            {\n              \"id\": \"5\",\n              \"name\": \"Taurus\"\n            },\n            {\n              \"id\": \"6\",\n              \"name\": \"Gemini\"\n            },\n            {\n              \"id\": \"7\",\n              \"name\": \"Cancer\"\n            },\n            {\n              \"id\": \"8\",\n              \"name\": \"Leo\"\n            },\n            {\n              \"id\": \"9\",\n              \"name\": \"Virgo\"\n            },\n            {\n              \"id\": \"10\",\n              \"name\": \"Libra\"\n            },\n            {\n              \"id\": \"11\",\n              \"name\": \"Scorpio\"\n            },\n            {\n              \"id\": \"12\",\n              \"name\": \"Sagittarius\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/astrological_sign@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/astrological_sign@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/astrological_sign@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/astrological_sign@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 5,\n          \"sectionName\": \"More about me\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_9\",\n          \"name\": \"Education\",\n          \"prompt\": \"What is your education level?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Bachelor degree\",\n              \"matchGroupKey\": \"Bachelors\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"At uni\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"High school\",\n              \"matchGroupKey\": \"Highschool\"\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"PhD\",\n              \"matchGroupKey\": \"PhD\"\n            },\n            {\n              \"id\": \"5\",\n              \"name\": \"On a graduate programme\"\n            },\n            {\n              \"id\": \"6\",\n              \"name\": \"Master degree\",\n              \"matchGroupKey\": \"Masters\"\n            },\n            {\n              \"id\": \"7\",\n              \"name\": \"Trade school\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/education@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/education@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/education@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/education@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 5,\n          \"sectionName\": \"More about me\",\n          \"matchGroupKey\": \"education\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_33\",\n          \"name\": \"Family plans\",\n          \"prompt\": \"Do you want children?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"I want children\",\n              \"matchGroupKey\": \"Yes\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"I don’t want children\",\n              \"matchGroupKey\": \"No\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"I have children and want more\"\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"I have children and don’t want more\"\n            },\n            {\n              \"id\": \"5\",\n              \"name\": \"Not sure yet\",\n              \"matchGroupKey\": \"Maybe\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/kids@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/kids@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/kids@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/kids@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 5,\n          \"sectionName\": \"More about me\",\n          \"matchGroupKey\": \"wants_children\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_34\",\n          \"name\": \"COVID vaccine\",\n          \"prompt\": \"Are you vaccinated?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Vaccinated\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Unvaccinated\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Prefer not to say\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/covid_comfort@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/covid_comfort@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/covid_comfort@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/covid_comfort@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 5,\n          \"sectionName\": \"More about me\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_13\",\n          \"name\": \"Personality type\",\n          \"prompt\": \"What’s your personality type?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"INTJ\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"INTP\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"ENTJ\"\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"ENTP\"\n            },\n            {\n              \"id\": \"5\",\n              \"name\": \"INFJ\"\n            },\n            {\n              \"id\": \"6\",\n              \"name\": \"INFP\"\n            },\n            {\n              \"id\": \"7\",\n              \"name\": \"ENFJ\"\n            },\n            {\n              \"id\": \"8\",\n              \"name\": \"ENFP\"\n            },\n            {\n              \"id\": \"9\",\n              \"name\": \"ISTJ\"\n            },\n            {\n              \"id\": \"10\",\n              \"name\": \"ISFJ\"\n            },\n            {\n              \"id\": \"11\",\n              \"name\": \"ESTJ\"\n            },\n            {\n              \"id\": \"12\",\n              \"name\": \"ESFJ\"\n            },\n            {\n              \"id\": \"13\",\n              \"name\": \"ISTP\"\n            },\n            {\n              \"id\": \"14\",\n              \"name\": \"ISFP\"\n            },\n            {\n              \"id\": \"15\",\n              \"name\": \"ESTP\"\n            },\n            {\n              \"id\": \"16\",\n              \"name\": \"ESFP\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/mbti@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/mbti@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/mbti@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/mbti@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 5,\n          \"sectionName\": \"More about me\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_2\",\n          \"name\": \"Communication style\",\n          \"prompt\": \"What’s your communication style?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Big time texter\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Phone caller\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Video chatter\"\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"Bad texter\"\n            },\n            {\n              \"id\": \"5\",\n              \"name\": \"Better in person\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/communication_style@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/communication_style@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/communication_style@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/communication_style@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 5,\n          \"sectionName\": \"More about me\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_35\",\n          \"name\": \"Love style\",\n          \"prompt\": \"How do you receive love?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Thoughtful gestures\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Presents\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Touch\"\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"Compliments\"\n            },\n            {\n              \"id\": \"5\",\n              \"name\": \"Time together\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/love_language@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/love_language@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/love_language@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/love_language@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 5,\n          \"sectionName\": \"More about me\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        }\n      ]", new System.Text.Json.JsonDocumentOptions()));

            migrationBuilder.UpdateData(
                table: "AvailableDescriptors",
                keyColumn: "Id",
                keyValue: 6,
                column: "Descriptors",
                value: System.Text.Json.JsonDocument.Parse("[\n        {\n          \"id\": \"de_3\",\n          \"name\": \"Pets\",\n          \"prompt\": \"Do you have any pets?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Dog\",\n              \"matchGroupKey\": \"Dogs\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Cat\",\n              \"matchGroupKey\": \"Cats\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Reptile\"\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"Amphibian\"\n            },\n            {\n              \"id\": \"8\",\n              \"name\": \"Bird\"\n            },\n            {\n              \"id\": \"5\",\n              \"name\": \"Fish\"\n            },\n            {\n              \"id\": \"9\",\n              \"name\": \"Don’t have, but love\"\n            },\n            {\n              \"id\": \"11\",\n              \"name\": \"Other\",\n              \"matchGroupKey\": \"Other\"\n            },\n            {\n              \"id\": \"12\",\n              \"name\": \"Turtle\"\n            },\n            {\n              \"id\": \"13\",\n              \"name\": \"Hamster\"\n            },\n            {\n              \"id\": \"14\",\n              \"name\": \"Rabbit\"\n            },\n            {\n              \"id\": \"6\",\n              \"name\": \"Pet-free\"\n            },\n            {\n              \"id\": \"7\",\n              \"name\": \"All the pets\"\n            },\n            {\n              \"id\": \"16\",\n              \"name\": \"Want a pet\"\n            },\n            {\n              \"id\": \"17\",\n              \"name\": \"Allergic to pets\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/pets@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/pets@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/pets@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/pets@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 6,\n          \"sectionName\": \"Lifestyle\",\n          \"matchGroupKey\": \"pets\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_22\",\n          \"name\": \"Drinking\",\n          \"prompt\": \"How often do you drink?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"8\",\n              \"name\": \"Not for me\",\n              \"matchGroupKey\": \"No\"\n            },\n            {\n              \"id\": \"9\",\n              \"name\": \"Newly teetotal\"\n            },\n            {\n              \"id\": \"10\",\n              \"name\": \"Sober curious\"\n            },\n            {\n              \"id\": \"11\",\n              \"name\": \"On special occasions\",\n              \"matchGroupKey\": \"Sometimes\"\n            },\n            {\n              \"id\": \"12\",\n              \"name\": \"Socially, at the weekend\",\n              \"matchGroupKey\": \"Socially\"\n            },\n            {\n              \"id\": \"13\",\n              \"name\": \"Most nights\",\n              \"matchGroupKey\": \"Yes\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/drink_of_choice@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/drink_of_choice@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/drink_of_choice@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/drink_of_choice@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 6,\n          \"sectionName\": \"Lifestyle\",\n          \"matchGroupKey\": \"drinking\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_11\",\n          \"name\": \"How often do you smoke?\",\n          \"prompt\": \"How often do you smoke?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Social smoker\",\n              \"matchGroupKey\": \"Socially\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Smoker when drinking\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Non-smoker\",\n              \"matchGroupKey\": \"No\"\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"Smoker\",\n              \"matchGroupKey\": \"Yes\"\n            },\n            {\n              \"id\": \"6\",\n              \"name\": \"Trying to quit\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/smoking@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/smoking@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/smoking@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/smoking@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 6,\n          \"sectionName\": \"Lifestyle\",\n          \"matchGroupKey\": \"drinking\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_10\",\n          \"name\": \"Workout\",\n          \"prompt\": \"Do you exercise?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"4\",\n              \"name\": \"Every day\"\n            },\n            {\n              \"id\": \"5\",\n              \"name\": \"Often\",\n              \"matchGroupKey\": \"Often\"\n            },\n            {\n              \"id\": \"6\",\n              \"name\": \"Sometimes\",\n              \"matchGroupKey\": \"Sometimes\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Never\",\n              \"matchGroupKey\": \"Never\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/workout@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/workout@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/workout@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/workout@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 6,\n          \"sectionName\": \"Lifestyle\",\n          \"matchGroupKey\": \"exercise\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_7\",\n          \"name\": \"Dietary preference\",\n          \"prompt\": \"What are your dietary preferences?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Vegan\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Vegetarian\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Pescatarian\"\n            },\n            {\n              \"id\": \"9\",\n              \"name\": \"Kosher\"\n            },\n            {\n              \"id\": \"10\",\n              \"name\": \"Halal\"\n            },\n            {\n              \"id\": \"7\",\n              \"name\": \"Carnivore\"\n            },\n            {\n              \"id\": \"8\",\n              \"name\": \"Omnivore\"\n            },\n            {\n              \"id\": \"12\",\n              \"name\": \"Other\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/appetite@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/appetite@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/appetite@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/appetite@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 6,\n          \"sectionName\": \"Lifestyle\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_4\",\n          \"name\": \"Social media\",\n          \"prompt\": \"How active are you on social media?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Influencer status\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Socially active\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Off the grid\"\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"Passive scroller\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/social_media@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/social_media@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/social_media@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/social_media@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 6,\n          \"sectionName\": \"Lifestyle\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_17\",\n          \"name\": \"Sleeping habits\",\n          \"prompt\": \"What are your sleeping habits?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Early bird\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Night owl\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"It varies\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/sleeping_habits@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/sleeping_habits@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/sleeping_habits@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/sleeping_habits@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 6,\n          \"sectionName\": \"Lifestyle\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        }\n      ]", new System.Text.Json.JsonDocumentOptions()));

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Description", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("0444a895-4ae2-4e28-8f6f-ccfadf23d636"), null, "Woman", null },
                    { new Guid("ea24110c-67d8-4eb9-b392-d1895e6de25e"), null, "Man", null },
                    { new Guid("ea80ea6f-c5b5-4764-8434-1e40172b02bf"), null, "Beyond binary", null }
                });

            migrationBuilder.InsertData(
                table: "QuestionCategories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6050), "Connection-building", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6050) },
                    { new Guid("4de1fe8e-c7c1-426e-845b-490e43af6ac1"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6020), "Sexual", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6020) },
                    { new Guid("74a79e0d-766c-44a5-88d1-2095b901af77"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6040), "Edgy", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6050) },
                    { new Guid("95e37d2a-ef00-489b-9431-4159e12e927a"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6040), "Flirty", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6040) },
                    { new Guid("b30a9e0c-3911-4ef3-8200-17d977bee894"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6030), "Funny", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6030) },
                    { new Guid("b5689f6c-0998-4d02-9c1f-f7db2b69fccd"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6060), "Dilemma", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6060) }
                });

            migrationBuilder.InsertData(
                table: "RoomContent",
                columns: new[] { "Id", "CreatedAt", "Description", "Duration", "Order", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("01e9df5c-e45b-4af2-af99-c76fd3c03e8b"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6780), "Give us the scoop on the person behind the screen!", 60m, 1, "Meet & Greet", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6780) },
                    { new Guid("16604575-78e6-40ad-a46c-2f97aab2ced5"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6810), "Pop your best question to the remaining contenders, and whoever nails it gets the match!", 60m, 5, "The Final Rose", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6810) },
                    { new Guid("26f70d7e-7bf6-46a0-b637-968492252710"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6790), "Share your passions and two quirky facts about yourself!", 120m, 2, "Hobby Showcase & Fun Fact Extravaganza", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6790) },
                    { new Guid("3e5d3180-088c-4182-9477-68a7245923a8"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6800), "Brace yourself for some off-the-wall questions and give your best answers within the time limit!", 300m, 3, "Random Question Roulette", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6800) },
                    { new Guid("79c46c9d-8b80-48f0-8df4-ad97f1300134"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6810), "Get ready to field questions from your adoring audience!", 300m, 4, "Spotlight Q&A", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6810) }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Description", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("044fd3c5-3aa8-4104-9ff7-06faaa6644e1"), "A woman whose gender is different from her sex assigned at birth.", "Trans woman", new Guid("0444a895-4ae2-4e28-8f6f-ccfadf23d636") },
                    { new Guid("0555c3a9-dc49-4e91-97e5-8b508ea24b0b"), "A person who was assigned female at birth, but presents as masculine. This person may or may not see themselves as a man or a transgender man.", "Transmasculine", new Guid("ea80ea6f-c5b5-4764-8434-1e40172b02bf") },
                    { new Guid("0d1b068a-b1b0-40d4-a0c0-8556cf52cf96"), "A person who has two or more genders (can be simultaneously or fluid between them).", "Bigender", new Guid("ea80ea6f-c5b5-4764-8434-1e40172b02bf") },
                    { new Guid("4664ba68-b2df-4f15-b202-825c3ad9e50d"), "A person who does not have a single fixed gender.", "Gender fluid", new Guid("ea80ea6f-c5b5-4764-8434-1e40172b02bf") },
                    { new Guid("4af1f7cd-3f93-4d93-94e8-8e8483461818"), "A person who does not have a gender.", "Agender", new Guid("ea80ea6f-c5b5-4764-8434-1e40172b02bf") },
                    { new Guid("525fa89c-e775-498c-ad93-46c22e1774f7"), "A person who was assigned male at birth, but presents as feminine. This person may or may not see themselves as a woman or a transgender woman.", "Transfeminine", new Guid("ea80ea6f-c5b5-4764-8434-1e40172b02bf") },
                    { new Guid("53ee1dd2-507f-435d-a0d9-37b61670c892"), "A person who was assigned female at birth, but presents as masculine. This person may or may not see themselves as a man or a transgender man.", "Transmasculine", new Guid("ea24110c-67d8-4eb9-b392-d1895e6de25e") },
                    { new Guid("63d4db0a-4f1f-4964-94c8-1ba48e7b82a6"), "A person whose gender is beyond the exclusive categories of man and woman.", "Non-binary", new Guid("ea80ea6f-c5b5-4764-8434-1e40172b02bf") },
                    { new Guid("671a223c-99e2-4b35-aeb4-645fd7ff5189"), "A person who is questioning their current gender and/or exploring other genders and expressions.", "Gender questioning", new Guid("ea80ea6f-c5b5-4764-8434-1e40172b02bf") },
                    { new Guid("71601893-494c-4ca3-898d-8666eb6e6674"), "A woman born with one or more variations in sex characteristics that don’t fit binary ideas of male or female bodies.", "Intersex woman", new Guid("0444a895-4ae2-4e28-8f6f-ccfadf23d636") },
                    { new Guid("87d61d5f-3e7e-4df7-afe5-2a055f863eeb"), "A woman whose gender aligns with the sex they were assigned at birth.", "Cis woman", new Guid("0444a895-4ae2-4e28-8f6f-ccfadf23d636") },
                    { new Guid("8d31a7d4-f90e-4d8c-b21d-b6d29df50249"), "A man whose gender aligns with the sex they were assigned at birth.", "Cis man", new Guid("ea24110c-67d8-4eb9-b392-d1895e6de25e") },
                    { new Guid("8e1d049f-4fd6-4dc8-82dd-f2f208200154"), "A man whose gender is different from his sex assigned at birth.", "Trans man", new Guid("ea24110c-67d8-4eb9-b392-d1895e6de25e") },
                    { new Guid("9f3d94a8-89fb-44e8-8a2b-71495f61d1d9"), "A person who does not identify or express their gender within the gender binary.", "Genderqueer", new Guid("ea80ea6f-c5b5-4764-8434-1e40172b02bf") },
                    { new Guid("ac65da0d-6053-4e2e-b619-628ec261c62b"), "An umbrella term that refers to people born with one or more variations in sex characteristics that don’t fit binary ideas of male or female bodies.", "Intersex", new Guid("ea80ea6f-c5b5-4764-8434-1e40172b02bf") },
                    { new Guid("bded0257-4d51-43ee-9b5c-f9f851bcbeb8"), "A person who is transgender and their gender is different from the sex assigned to them at birth.", "Trans person", new Guid("ea80ea6f-c5b5-4764-8434-1e40172b02bf") },
                    { new Guid("c684097c-4b55-4a18-be32-a95e348d61ff"), "An umbrella term used across US Native American and Canadian First Nations communities to honour the sacred role that people who are not exclusively cisgender and/or heterosexual hold.", "Two-Spirit", new Guid("ea80ea6f-c5b5-4764-8434-1e40172b02bf") },
                    { new Guid("dc40ad8f-b6c3-486b-a8f5-c951718cb2dc"), "A person who was assigned male at birth, but presents as feminine. This person may or may not see themselves as a woman or a transgender woman.", "Transfeminine", new Guid("0444a895-4ae2-4e28-8f6f-ccfadf23d636") },
                    { new Guid("f1171c3c-04d8-4d40-9cd0-5e586ba5f828"), "A man born with one or more variations in sex characteristics that don’t fit binary ideas of male or female bodies.", "Intersex man", new Guid("ea24110c-67d8-4eb9-b392-d1895e6de25e") },
                    { new Guid("f1e4cbe9-6aae-4b32-9b11-981d48b8b36d"), "A person who experiences multiple genders either simultaneously or over time.", "Pangender", new Guid("ea80ea6f-c5b5-4764-8434-1e40172b02bf") }
                });

            migrationBuilder.InsertData(
                table: "SystemQuestions",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("01d4f167-7efc-48b9-ab71-ab676c6d5d90"), new Guid("b30a9e0c-3911-4ef3-8200-17d977bee894"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6240), "Do you think that men can be gynecologists? (Second question) What if he sniffs his finger?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6250) },
                    { new Guid("037e05fc-660e-4c23-b05e-31d335239a2e"), new Guid("b5689f6c-0998-4d02-9c1f-f7db2b69fccd"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6700), "Burger or pizza?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6700) },
                    { new Guid("077b5f0f-7746-403a-b7ab-a1c7f92248c0"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6650), "What do you wish more people knew about you?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6650) },
                    { new Guid("07ced984-46a7-41fa-9d27-3a4eec34b019"), new Guid("4de1fe8e-c7c1-426e-845b-490e43af6ac1"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6160), "Are you more dominant or submissive in bed?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6160) },
                    { new Guid("0c0987cd-f8e2-4989-9428-ead72da8476c"), new Guid("4de1fe8e-c7c1-426e-845b-490e43af6ac1"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6120), "Do you prefer firm or light touches?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6120) },
                    { new Guid("0d00670b-a142-4f18-873a-eb17d9c163ef"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6490), "If you could ask your pet 3 questions, what would they be?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6490) },
                    { new Guid("10a8153d-33f8-4a03-b050-188567cd4801"), new Guid("4de1fe8e-c7c1-426e-845b-490e43af6ac1"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6220), "Where do you like to be touched most?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6220) },
                    { new Guid("18c5e6bf-f9f5-4318-a4f7-b056f2fd335b"), new Guid("b30a9e0c-3911-4ef3-8200-17d977bee894"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6280), "If your friends and family hear that you were arrested, what would they think you did?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6280) },
                    { new Guid("1e0fec3e-34cf-4db4-b827-17684f6f9e47"), new Guid("4de1fe8e-c7c1-426e-845b-490e43af6ac1"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6210), "What are your thoughts on toys?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6210) },
                    { new Guid("1f1883ad-c45b-4ab1-9780-77bbb3fc1b78"), new Guid("74a79e0d-766c-44a5-88d1-2095b901af77"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6430), "Would you rather Win $50,000 or let your best friend win $500,000?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6430) },
                    { new Guid("272e4b4e-be19-44a3-8a99-78c85c7083f0"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6520), "If you were the mayor of your city, what rule would you instantly enforce?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6520) },
                    { new Guid("276acb4f-da86-4ea6-95ce-12922c9f02b6"), new Guid("95e37d2a-ef00-489b-9431-4159e12e927a"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6380), "Do you prefer cuddling or kissing?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6380) },
                    { new Guid("2b1f6fae-1ada-486a-a1ed-aec75dbd810e"), new Guid("95e37d2a-ef00-489b-9431-4159e12e927a"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6390), "What do you wear when you go to sleep?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6390) },
                    { new Guid("2e3f2421-868b-45d0-819a-2e3c08cf6f62"), new Guid("b5689f6c-0998-4d02-9c1f-f7db2b69fccd"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6690), "Love or money?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6690) },
                    { new Guid("2e88a1fd-a206-4551-98ad-9717fe9af393"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6510), "What’s the most romantic thing you’ve ever done for someone?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6510) },
                    { new Guid("31e319dc-f56a-46ca-9584-43ca8ac67281"), new Guid("4de1fe8e-c7c1-426e-845b-490e43af6ac1"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6210), "What’s the dirtiest thing someone said to you during sex?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6210) },
                    { new Guid("3326b3da-54c7-425a-8444-ea9f73885831"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6580), "What dating advice would you give your younger self?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6580) },
                    { new Guid("33480e88-90cb-4120-bbc1-e5031b7341d8"), new Guid("b5689f6c-0998-4d02-9c1f-f7db2b69fccd"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6670), "Peanut butter or Nutella?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6670) },
                    { new Guid("3de971e3-5173-4579-89f9-90cce101abb8"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6470), "Would you rather travel to the past or the future?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6470) },
                    { new Guid("3e45b683-2615-4378-8485-182580ec07b2"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6610), "What’s the one compliment you get the most?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6610) },
                    { new Guid("40020551-54a4-4b99-b6f0-ff8c8b0ad7d7"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6620), "What do you wish you cared less about?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6620) },
                    { new Guid("4038041f-c6d7-45ac-95ea-e7db0dee51c8"), new Guid("b30a9e0c-3911-4ef3-8200-17d977bee894"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6310), "You’re at a party and really need to drop a deuce. But their toilet doesn’t flush. Do you use the toilet anyway, or do your business in the yard?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6310) },
                    { new Guid("4508fba0-44a3-42e8-ab81-ff19a04089a2"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6470), "If you could travel the universe on the condition that you were never allowed to set foot on earth again, would you go?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6470) },
                    { new Guid("462f1a4a-a209-4ed6-aadd-f31349226bd0"), new Guid("4de1fe8e-c7c1-426e-845b-490e43af6ac1"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6140), "Do you think it’s okay if a guy wants to be submissive in the bedroom?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6140) },
                    { new Guid("46dc52ea-0651-4a50-8f4a-bb6fe687f413"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6580), "What’s something that gives your life meaning?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6580) },
                    { new Guid("4f0b8c16-ed24-43b0-bebb-aa8ce36b76f9"), new Guid("74a79e0d-766c-44a5-88d1-2095b901af77"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6390), "Would you rather have a cat with a human face or a dog with human hands?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6390) },
                    { new Guid("5229f058-d14a-4564-a505-ee38ac0f8db7"), new Guid("74a79e0d-766c-44a5-88d1-2095b901af77"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6440), "Would you rather be with the person you love forever, but also wear a shirt made out of their pubes, or be alone for the rest of your life but wear whatever you want?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6440) },
                    { new Guid("533367b0-3bb1-4a22-9164-2baeff8bab26"), new Guid("4de1fe8e-c7c1-426e-845b-490e43af6ac1"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6180), "Have you ever had sex with someone you just met?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6180) },
                    { new Guid("59e9f355-4333-4ad0-bd5b-d51be4ff38f2"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6500), "What’s something you’d like to be remembered for?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6500) },
                    { new Guid("5f28bdd2-db64-40d8-b757-f85bca832b7a"), new Guid("b30a9e0c-3911-4ef3-8200-17d977bee894"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6260), "Would you date someone who’s cute but mega dumb?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6260) },
                    { new Guid("61e6c08d-75a1-4adf-b687-eff34d1043d8"), new Guid("95e37d2a-ef00-489b-9431-4159e12e927a"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6370), "What’s the hottest thing a guy can do for you?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6370) },
                    { new Guid("63010bb4-1806-4d33-bc90-dea0129f54c7"), new Guid("b5689f6c-0998-4d02-9c1f-f7db2b69fccd"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6680), "Bath or shower?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6680) },
                    { new Guid("69269428-4211-4d2e-b8fd-2737717b0054"), new Guid("4de1fe8e-c7c1-426e-845b-490e43af6ac1"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6190), "What’s the dirtiest thought you’ve ever had about a stranger?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6190) },
                    { new Guid("699f282a-e2ec-430b-aef6-a06899cf78c3"), new Guid("74a79e0d-766c-44a5-88d1-2095b901af77"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6420), "Would you rather speak every language fluently or play every instrument perfectly?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6420) },
                    { new Guid("6ada8372-1381-480b-8b0f-d61d2fb69cc8"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6490), "What’s the first thing you do when you get back home from work?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6490) },
                    { new Guid("6f5119ae-ccc2-46c8-aeb7-01407027fd3c"), new Guid("b30a9e0c-3911-4ef3-8200-17d977bee894"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6300), "Do you prefer the smell of freshly cut grass or freshly baked bread?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6300) },
                    { new Guid("722a6f66-240c-4fcc-a2ed-f1ec09c754b4"), new Guid("b30a9e0c-3911-4ef3-8200-17d977bee894"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6270), "You have to assassinate someone who really deserves it. How do you do it?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6270) },
                    { new Guid("74548ecb-cc5d-40c9-98cf-0d5936c71ef9"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6560), "Would you continue working if you were rich and didn’t need to?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6560) },
                    { new Guid("783f3a9b-85f5-4be5-af8c-4488ec31072b"), new Guid("95e37d2a-ef00-489b-9431-4159e12e927a"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6320), "What’s your favorite way to be seduced by a man?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6320) },
                    { new Guid("7bdf9da2-3d0e-42cc-b4e3-65119e969e40"), new Guid("b5689f6c-0998-4d02-9c1f-f7db2b69fccd"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6700), "Dine-in or delivery?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6700) },
                    { new Guid("7c26e8b8-4859-4e34-9da6-ed30ebeac574"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6650), "What’s the most important thing your life is missing?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6650) },
                    { new Guid("7f88d1e6-943f-4ae0-8ad1-7f584f684987"), new Guid("4de1fe8e-c7c1-426e-845b-490e43af6ac1"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6150), "Do you prefer to make out with the lights on or off?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6150) },
                    { new Guid("81aeecb0-81f1-446c-9657-072198bc83fe"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6630), "What do your friends and family call you?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6630) },
                    { new Guid("83e43130-6ae9-4e85-97d2-f86fe99ba352"), new Guid("95e37d2a-ef00-489b-9431-4159e12e927a"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6320), "What do you miss most about being single? (She has to pick something.)", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6320) },
                    { new Guid("86cf9758-bf86-471a-b92b-f8afbf53fc11"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6460), "Name three things that you can do to get out of a funk.", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6460) },
                    { new Guid("87694951-16a0-481a-9f20-fde6fb48ea45"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6510), "Is there a way you could fall head over heels for a man? What would that look like?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6510) },
                    { new Guid("87d4d6a5-e79c-40d5-9ba4-56683bbf0de0"), new Guid("95e37d2a-ef00-489b-9431-4159e12e927a"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6330), "What’s the best romantic surprise you’ve ever had?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6330) },
                    { new Guid("8a59f8e6-54b2-45bc-9ad7-150bc672a6bb"), new Guid("4de1fe8e-c7c1-426e-845b-490e43af6ac1"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6130), "Do guy-on-guy videos turn you on more than guy-on-girl?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6130) },
                    { new Guid("8bec33e0-79ae-45de-beac-f8b9946ff261"), new Guid("b30a9e0c-3911-4ef3-8200-17d977bee894"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6290), "You’re on a first date with a dude you like and you let out an audible fart. What do you do?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6290) },
                    { new Guid("8c1749a7-203c-4e8a-b3fb-abc2181689f5"), new Guid("b30a9e0c-3911-4ef3-8200-17d977bee894"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6230), "What meal or snack will you never refuse?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6230) },
                    { new Guid("8d32bc47-26a2-41c9-9218-f7e8751a91cd"), new Guid("74a79e0d-766c-44a5-88d1-2095b901af77"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6410), "Would you rather fight young Mike Tyson once or talk like Mike Tyson for the rest of your life?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6410) },
                    { new Guid("91df1363-0ae9-4610-b3f1-14e8c9a68244"), new Guid("74a79e0d-766c-44a5-88d1-2095b901af77"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6440), "Would you rather be stung by a thousand bees or stomp a kitten?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6440) },
                    { new Guid("927a03ed-5102-49a1-93e6-3a0a638c06a5"), new Guid("4de1fe8e-c7c1-426e-845b-490e43af6ac1"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6140), "Would you rather receive or give oral?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6140) },
                    { new Guid("93975291-b954-4ce2-8ac7-3d8cf4b1af81"), new Guid("95e37d2a-ef00-489b-9431-4159e12e927a"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6350), "What do you think is the most important thing a woman can give to a man?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6350) },
                    { new Guid("961b76bd-751f-40c9-9b44-1c7b7050fa20"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6620), "Where do you feel the most at home?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6620) },
                    { new Guid("975709e5-ca23-4fcb-aac9-600eb0f49692"), new Guid("95e37d2a-ef00-489b-9431-4159e12e927a"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6370), "Can you surrender to love or is it something that scares you?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6370) },
                    { new Guid("98082fc7-6549-4123-9ee7-696d710f452b"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6600), "If you could only put on one piece of makeup, what would it be?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6600) },
                    { new Guid("9e6dd634-8862-4ff8-a385-9f60619179c4"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6550), "What’s something you’ve always wanted to do, but haven’t?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6550) },
                    { new Guid("9fa19759-f1a9-4cc0-9ab5-757dd7088cb1"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6480), "If you could make one decision to change the world, what would you do?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6480) },
                    { new Guid("a6ad9e32-fc48-461c-81b7-588972f0ad8b"), new Guid("4de1fe8e-c7c1-426e-845b-490e43af6ac1"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6110), "What physical act gives you the most pleasure?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6110) },
                    { new Guid("b44949e6-5e25-4df5-b496-f75dbd180dbe"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6560), "What does your ideal night look like? Do you go out or are you at home with friends?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6560) },
                    { new Guid("b5100b7f-bf6e-4749-b859-fba3193ccf4c"), new Guid("b30a9e0c-3911-4ef3-8200-17d977bee894"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6240), "What’s the weirdest thing you carry in your purse?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6240) },
                    { new Guid("b80aece3-59f1-4876-9239-98fd41eec468"), new Guid("95e37d2a-ef00-489b-9431-4159e12e927a"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6340), "What does good sex mean to you?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6340) },
                    { new Guid("b8792ace-b74d-422d-b981-e376cd2cd716"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6460), "What’s a recent book you read or movie you saw that taught you something?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6460) },
                    { new Guid("be5e623e-4413-491d-9016-390d0c35b9ec"), new Guid("95e37d2a-ef00-489b-9431-4159e12e927a"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6350), "What are your biggest turn-offs?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6350) },
                    { new Guid("c03737d1-d798-41c7-9490-6289fa9d3040"), new Guid("b30a9e0c-3911-4ef3-8200-17d977bee894"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6260), "What’s the last time you did something scary?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6260) },
                    { new Guid("c1523af0-5434-4dc0-bdff-7997c524a507"), new Guid("4de1fe8e-c7c1-426e-845b-490e43af6ac1"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6200), "If a cute couple asked you to do a threesome, would you say yes?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6200) },
                    { new Guid("c68f3151-e036-48d3-a712-e9b2661e6f4a"), new Guid("4de1fe8e-c7c1-426e-845b-490e43af6ac1"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6170), "Do you like to roleplay?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6170) },
                    { new Guid("c8751e1d-076e-4699-9d35-40ce0ebea615"), new Guid("b5689f6c-0998-4d02-9c1f-f7db2b69fccd"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6660), "Flight or invisibility?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6670) },
                    { new Guid("ca5b9af5-a899-4350-8df5-eccdb1395b85"), new Guid("b30a9e0c-3911-4ef3-8200-17d977bee894"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6280), "You and all your friends have to enter a mixed martial arts tournament. Do you win?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6280) },
                    { new Guid("cac2765e-45ac-47da-bd71-7c33fe96f910"), new Guid("74a79e0d-766c-44a5-88d1-2095b901af77"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6420), "Would you rather be surrounded by people who brag all the time or by people who constantly complain?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6420) },
                    { new Guid("cbf6f835-8d92-4d8d-9ed7-34648a0f6e37"), new Guid("95e37d2a-ef00-489b-9431-4159e12e927a"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6340), "What do you find the most attractive in a man?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6340) },
                    { new Guid("cf130d54-6bd4-4127-b2e3-91538bf20f05"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6590), "What song would you want to play on your wedding day?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6590) },
                    { new Guid("d25ac35a-7f23-433c-8c56-d897dc4b0851"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6640), "What’s something you swear by?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6640) },
                    { new Guid("d296d076-7407-47fc-b028-6b33f15357fb"), new Guid("4de1fe8e-c7c1-426e-845b-490e43af6ac1"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6150), "Would you rather end a good first date with a passionate kiss or sex?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6150) },
                    { new Guid("d621929f-0b1b-4b2d-a350-853e8eaf93cd"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6600), "What would you like to get for your birthday?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6600) },
                    { new Guid("d644109e-5536-4533-8480-92ef058a51ca"), new Guid("b30a9e0c-3911-4ef3-8200-17d977bee894"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6250), "What was the last time you went skinny dipping?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6250) },
                    { new Guid("d6b9a671-7c68-468f-8136-d0bbda27aea1"), new Guid("b30a9e0c-3911-4ef3-8200-17d977bee894"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6230), "Zombies are overrunning the world. How do you defend yourself?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6230) },
                    { new Guid("d9afffe8-c6a9-4f09-858f-4407a8539c24"), new Guid("74a79e0d-766c-44a5-88d1-2095b901af77"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6400), "Would you rather have a boyfriend who’s stinking rich and ugly? Or a friend who’s dirt poor and handsome?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6400) },
                    { new Guid("e087cf0e-2135-4350-8d36-b3d208121aea"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6630), "Where do you go if you want to escape?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6630) },
                    { new Guid("e0930181-bbd0-43a6-ba62-ff748b9d49ac"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6520), "What’s your favorite and least favorite household chore?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6520) },
                    { new Guid("e1c5a9e0-3299-4b3e-a071-b3b1bc25a815"), new Guid("4de1fe8e-c7c1-426e-845b-490e43af6ac1"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6170), "What do you fantasize about when you touch yourself?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6170) },
                    { new Guid("e4f3ebfb-a1d4-47b7-904d-576a59310ed9"), new Guid("74a79e0d-766c-44a5-88d1-2095b901af77"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6450), "Your dad and boyfriend switch bodies (Freaky Friday style). The only way to switch them back is to have sex with them, lights on and sober. Who do you pick?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6450) },
                    { new Guid("e6b7bd0a-7f45-471a-98ca-4405b864a6b5"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6660), "How long ago did you tell someone you loved them?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6660) },
                    { new Guid("ec84a257-4e70-44fd-80f9-06c58058d30d"), new Guid("b30a9e0c-3911-4ef3-8200-17d977bee894"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6300), "You find out your best friend is a lesbian and she’s in love with you. How do you react?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6300) },
                    { new Guid("ef09ed4c-6187-4908-a4ae-a74be1f859f0"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6570), "If you could change one thing about the way you were raised, what would that be?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6570) },
                    { new Guid("ef423abd-7692-4cf5-8159-309b47919b9f"), new Guid("b5689f6c-0998-4d02-9c1f-f7db2b69fccd"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6680), "Quit coffee or never have snacks during films and series?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6680) },
                    { new Guid("f11e091c-0ba6-4a6c-8b27-c69ca3ad4ee6"), new Guid("95e37d2a-ef00-489b-9431-4159e12e927a"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6360), "What makes you feel sexy?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6360) },
                    { new Guid("f41c4fa4-890e-44fe-8e3c-a20690fda235"), new Guid("4de1fe8e-c7c1-426e-845b-490e43af6ac1"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6190), "What does your ideal one-night stand look like?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6190) },
                    { new Guid("fab60a22-fe6c-4759-b48c-00cae7841211"), new Guid("74a79e0d-766c-44a5-88d1-2095b901af77"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6400), "Would you rather have hiccups for the rest of your life or constantly feel like you have to sneeze?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6400) },
                    { new Guid("fb72ed97-1759-4ac2-8fb8-78f241112cfa"), new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"), new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6540), "What’s one responsibility of yours that you’d prefer to delegate to a professional?", new DateTime(2024, 11, 21, 10, 48, 0, 95, DateTimeKind.Utc).AddTicks(6550) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bf1dc63-e8bb-47ee-8c6a-28c5b90d15d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e23f453a-bc99-44c9-a2b5-211f2118d3f5");

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("044fd3c5-3aa8-4104-9ff7-06faaa6644e1"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("0555c3a9-dc49-4e91-97e5-8b508ea24b0b"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("0d1b068a-b1b0-40d4-a0c0-8556cf52cf96"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("4664ba68-b2df-4f15-b202-825c3ad9e50d"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("4af1f7cd-3f93-4d93-94e8-8e8483461818"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("525fa89c-e775-498c-ad93-46c22e1774f7"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("53ee1dd2-507f-435d-a0d9-37b61670c892"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("63d4db0a-4f1f-4964-94c8-1ba48e7b82a6"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("671a223c-99e2-4b35-aeb4-645fd7ff5189"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("71601893-494c-4ca3-898d-8666eb6e6674"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("87d61d5f-3e7e-4df7-afe5-2a055f863eeb"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("8d31a7d4-f90e-4d8c-b21d-b6d29df50249"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("8e1d049f-4fd6-4dc8-82dd-f2f208200154"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("9f3d94a8-89fb-44e8-8a2b-71495f61d1d9"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("ac65da0d-6053-4e2e-b619-628ec261c62b"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("bded0257-4d51-43ee-9b5c-f9f851bcbeb8"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("c684097c-4b55-4a18-be32-a95e348d61ff"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("dc40ad8f-b6c3-486b-a8f5-c951718cb2dc"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("f1171c3c-04d8-4d40-9cd0-5e586ba5f828"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("f1e4cbe9-6aae-4b32-9b11-981d48b8b36d"));

            migrationBuilder.DeleteData(
                table: "RoomContent",
                keyColumn: "Id",
                keyValue: new Guid("01e9df5c-e45b-4af2-af99-c76fd3c03e8b"));

            migrationBuilder.DeleteData(
                table: "RoomContent",
                keyColumn: "Id",
                keyValue: new Guid("16604575-78e6-40ad-a46c-2f97aab2ced5"));

            migrationBuilder.DeleteData(
                table: "RoomContent",
                keyColumn: "Id",
                keyValue: new Guid("26f70d7e-7bf6-46a0-b637-968492252710"));

            migrationBuilder.DeleteData(
                table: "RoomContent",
                keyColumn: "Id",
                keyValue: new Guid("3e5d3180-088c-4182-9477-68a7245923a8"));

            migrationBuilder.DeleteData(
                table: "RoomContent",
                keyColumn: "Id",
                keyValue: new Guid("79c46c9d-8b80-48f0-8df4-ad97f1300134"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("01d4f167-7efc-48b9-ab71-ab676c6d5d90"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("037e05fc-660e-4c23-b05e-31d335239a2e"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("077b5f0f-7746-403a-b7ab-a1c7f92248c0"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("07ced984-46a7-41fa-9d27-3a4eec34b019"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("0c0987cd-f8e2-4989-9428-ead72da8476c"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("0d00670b-a142-4f18-873a-eb17d9c163ef"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("10a8153d-33f8-4a03-b050-188567cd4801"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("18c5e6bf-f9f5-4318-a4f7-b056f2fd335b"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("1e0fec3e-34cf-4db4-b827-17684f6f9e47"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("1f1883ad-c45b-4ab1-9780-77bbb3fc1b78"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("272e4b4e-be19-44a3-8a99-78c85c7083f0"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("276acb4f-da86-4ea6-95ce-12922c9f02b6"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("2b1f6fae-1ada-486a-a1ed-aec75dbd810e"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("2e3f2421-868b-45d0-819a-2e3c08cf6f62"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("2e88a1fd-a206-4551-98ad-9717fe9af393"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("31e319dc-f56a-46ca-9584-43ca8ac67281"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("3326b3da-54c7-425a-8444-ea9f73885831"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("33480e88-90cb-4120-bbc1-e5031b7341d8"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("3de971e3-5173-4579-89f9-90cce101abb8"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("3e45b683-2615-4378-8485-182580ec07b2"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("40020551-54a4-4b99-b6f0-ff8c8b0ad7d7"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("4038041f-c6d7-45ac-95ea-e7db0dee51c8"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("4508fba0-44a3-42e8-ab81-ff19a04089a2"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("462f1a4a-a209-4ed6-aadd-f31349226bd0"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("46dc52ea-0651-4a50-8f4a-bb6fe687f413"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("4f0b8c16-ed24-43b0-bebb-aa8ce36b76f9"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("5229f058-d14a-4564-a505-ee38ac0f8db7"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("533367b0-3bb1-4a22-9164-2baeff8bab26"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("59e9f355-4333-4ad0-bd5b-d51be4ff38f2"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("5f28bdd2-db64-40d8-b757-f85bca832b7a"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("61e6c08d-75a1-4adf-b687-eff34d1043d8"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("63010bb4-1806-4d33-bc90-dea0129f54c7"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("69269428-4211-4d2e-b8fd-2737717b0054"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("699f282a-e2ec-430b-aef6-a06899cf78c3"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("6ada8372-1381-480b-8b0f-d61d2fb69cc8"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("6f5119ae-ccc2-46c8-aeb7-01407027fd3c"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("722a6f66-240c-4fcc-a2ed-f1ec09c754b4"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("74548ecb-cc5d-40c9-98cf-0d5936c71ef9"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("783f3a9b-85f5-4be5-af8c-4488ec31072b"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("7bdf9da2-3d0e-42cc-b4e3-65119e969e40"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("7c26e8b8-4859-4e34-9da6-ed30ebeac574"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("7f88d1e6-943f-4ae0-8ad1-7f584f684987"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("81aeecb0-81f1-446c-9657-072198bc83fe"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("83e43130-6ae9-4e85-97d2-f86fe99ba352"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("86cf9758-bf86-471a-b92b-f8afbf53fc11"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("87694951-16a0-481a-9f20-fde6fb48ea45"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("87d4d6a5-e79c-40d5-9ba4-56683bbf0de0"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("8a59f8e6-54b2-45bc-9ad7-150bc672a6bb"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("8bec33e0-79ae-45de-beac-f8b9946ff261"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("8c1749a7-203c-4e8a-b3fb-abc2181689f5"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("8d32bc47-26a2-41c9-9218-f7e8751a91cd"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("91df1363-0ae9-4610-b3f1-14e8c9a68244"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("927a03ed-5102-49a1-93e6-3a0a638c06a5"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("93975291-b954-4ce2-8ac7-3d8cf4b1af81"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("961b76bd-751f-40c9-9b44-1c7b7050fa20"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("975709e5-ca23-4fcb-aac9-600eb0f49692"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("98082fc7-6549-4123-9ee7-696d710f452b"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("9e6dd634-8862-4ff8-a385-9f60619179c4"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("9fa19759-f1a9-4cc0-9ab5-757dd7088cb1"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("a6ad9e32-fc48-461c-81b7-588972f0ad8b"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("b44949e6-5e25-4df5-b496-f75dbd180dbe"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("b5100b7f-bf6e-4749-b859-fba3193ccf4c"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("b80aece3-59f1-4876-9239-98fd41eec468"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("b8792ace-b74d-422d-b981-e376cd2cd716"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("be5e623e-4413-491d-9016-390d0c35b9ec"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("c03737d1-d798-41c7-9490-6289fa9d3040"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("c1523af0-5434-4dc0-bdff-7997c524a507"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("c68f3151-e036-48d3-a712-e9b2661e6f4a"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("c8751e1d-076e-4699-9d35-40ce0ebea615"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("ca5b9af5-a899-4350-8df5-eccdb1395b85"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("cac2765e-45ac-47da-bd71-7c33fe96f910"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("cbf6f835-8d92-4d8d-9ed7-34648a0f6e37"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("cf130d54-6bd4-4127-b2e3-91538bf20f05"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("d25ac35a-7f23-433c-8c56-d897dc4b0851"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("d296d076-7407-47fc-b028-6b33f15357fb"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("d621929f-0b1b-4b2d-a350-853e8eaf93cd"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("d644109e-5536-4533-8480-92ef058a51ca"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("d6b9a671-7c68-468f-8136-d0bbda27aea1"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("d9afffe8-c6a9-4f09-858f-4407a8539c24"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("e087cf0e-2135-4350-8d36-b3d208121aea"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("e0930181-bbd0-43a6-ba62-ff748b9d49ac"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("e1c5a9e0-3299-4b3e-a071-b3b1bc25a815"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("e4f3ebfb-a1d4-47b7-904d-576a59310ed9"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("e6b7bd0a-7f45-471a-98ca-4405b864a6b5"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("ec84a257-4e70-44fd-80f9-06c58058d30d"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("ef09ed4c-6187-4908-a4ae-a74be1f859f0"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("ef423abd-7692-4cf5-8159-309b47919b9f"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f11e091c-0ba6-4a6c-8b27-c69ca3ad4ee6"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("f41c4fa4-890e-44fe-8e3c-a20690fda235"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("fab60a22-fe6c-4759-b48c-00cae7841211"));

            migrationBuilder.DeleteData(
                table: "SystemQuestions",
                keyColumn: "Id",
                keyValue: new Guid("fb72ed97-1759-4ac2-8fb8-78f241112cfa"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("0444a895-4ae2-4e28-8f6f-ccfadf23d636"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("ea24110c-67d8-4eb9-b392-d1895e6de25e"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("ea80ea6f-c5b5-4764-8434-1e40172b02bf"));

            migrationBuilder.DeleteData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: new Guid("496f45ab-0eb9-4cfc-9e09-f06f0c760645"));

            migrationBuilder.DeleteData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: new Guid("4de1fe8e-c7c1-426e-845b-490e43af6ac1"));

            migrationBuilder.DeleteData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: new Guid("74a79e0d-766c-44a5-88d1-2095b901af77"));

            migrationBuilder.DeleteData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: new Guid("95e37d2a-ef00-489b-9431-4159e12e927a"));

            migrationBuilder.DeleteData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: new Guid("b30a9e0c-3911-4ef3-8200-17d977bee894"));

            migrationBuilder.DeleteData(
                table: "QuestionCategories",
                keyColumn: "Id",
                keyValue: new Guid("b5689f6c-0998-4d02-9c1f-f7db2b69fccd"));

            migrationBuilder.DropColumn(
                name: "UserProfileGenderPreferences",
                table: "UserProfiles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "895c6a7c-36e1-4e66-bfe2-abf99fbac40f", null, "User", "USER" },
                    { "d78cfc52-53f6-439e-909a-a12254eaaa54", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AvailableDescriptors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Descriptors",
                value: System.Text.Json.JsonDocument.Parse("[\n        {\n          \"id\": \"de_30\",\n          \"prompt\": \"Here’s where you can add your height to your profile.\",\n          \"type\": \"measurement\",\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/height@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/height@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 16,\n              \"height\": 16\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/height@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 32,\n              \"height\": 32\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/height@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 48,\n              \"height\": 48\n            }\n          ],\n          \"backgroundText\": \"Add height\",\n          \"measurableDetails\": {\n            \"min\": 90,\n            \"max\": 241,\n            \"unitOfMeasure\": \"cm\",\n            \"defaultUnitOfMeasure\": \"cm\"\n          },\n          \"sectionId\": 1,\n          \"sectionName\": \"Height\",\n          \"matchGroupKey\": \"height\",\n          \"discoveryPreferencesEnabled\": false\n        }\n      ]", new System.Text.Json.JsonDocumentOptions()));

            migrationBuilder.UpdateData(
                table: "AvailableDescriptors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Descriptors",
                value: System.Text.Json.JsonDocument.Parse("[\n        {\n          \"id\": \"de_37\",\n          \"type\": \"multiSelectionSet\",\n          \"choices\": [\n            {\n              \"id\": \"it_2275\",\n              \"name\": \"Harry Potter\"\n            },\n            {\n              \"id\": \"it_2033\",\n              \"name\": \"’90s kid\"\n            },\n            {\n              \"id\": \"it_2396\",\n              \"name\": \"SoundCloud\"\n            },\n            {\n              \"id\": \"it_2397\",\n              \"name\": \"Spa\"\n            },\n            {\n              \"id\": \"it_2155\",\n              \"name\": \"Self-care\"\n            },\n            {\n              \"id\": \"it_2276\",\n              \"name\": \"Heavy metal\"\n            },\n            {\n              \"id\": \"it_2031\",\n              \"name\": \"House parties\"\n            },\n            {\n              \"id\": \"it_2152\",\n              \"name\": \"Gin & tonic\"\n            },\n            {\n              \"id\": \"it_2273\",\n              \"name\": \"Gymnastics\"\n            },\n            {\n              \"id\": \"it_2279\",\n              \"name\": \"Hot yoga\"\n            },\n            {\n              \"id\": \"it_2159\",\n              \"name\": \"Meditation\"\n            },\n            {\n              \"id\": \"it_2398\",\n              \"name\": \"Spotify\"\n            },\n            {\n              \"id\": \"it_2035\",\n              \"name\": \"Sushi\"\n            },\n            {\n              \"id\": \"it_2277\",\n              \"name\": \"Hockey\"\n            },\n            {\n              \"id\": \"it_2156\",\n              \"name\": \"Basketball\"\n            },\n            {\n              \"id\": \"it_2036\",\n              \"name\": \"Slam poetry\"\n            },\n            {\n              \"id\": \"it_2278\",\n              \"name\": \"Home workouts\"\n            },\n            {\n              \"id\": \"it_2157\",\n              \"name\": \"Theatre\"\n            },\n            {\n              \"id\": \"it_33\",\n              \"name\": \"Café hopping\"\n            },\n            {\n              \"id\": \"it_36\",\n              \"name\": \"Aquarium\"\n            },\n            {\n              \"id\": \"it_2039\",\n              \"name\": \"Trainers\"\n            },\n            {\n              \"id\": \"it_35\",\n              \"name\": \"Instagram\"\n            },\n            {\n              \"id\": \"it_30\",\n              \"name\": \"Hot springs\"\n            },\n            {\n              \"id\": \"it_31\",\n              \"name\": \"Walking\"\n            },\n            {\n              \"id\": \"it_4\",\n              \"name\": \"Running\"\n            },\n            {\n              \"id\": \"it_7\",\n              \"name\": \"Travel\"\n            },\n            {\n              \"id\": \"it_6\",\n              \"name\": \"Language exchange\"\n            },\n            {\n              \"id\": \"it_9\",\n              \"name\": \"Films\"\n            },\n            {\n              \"id\": \"it_2271\",\n              \"name\": \"Guitarists\"\n            },\n            {\n              \"id\": \"it_2392\",\n              \"name\": \"Social development\"\n            },\n            {\n              \"id\": \"it_2272\",\n              \"name\": \"Gym\"\n            },\n            {\n              \"id\": \"it_2393\",\n              \"name\": \"Social media\"\n            },\n            {\n              \"id\": \"it_2030\",\n              \"name\": \"Hip hop\"\n            },\n            {\n              \"id\": \"it_2390\",\n              \"name\": \"Skincare\"\n            },\n            {\n              \"id\": \"it_2022\",\n              \"name\": \"J-Pop\"\n            },\n            {\n              \"id\": \"it_2386\",\n              \"name\": \"Shisha\"\n            },\n            {\n              \"id\": \"it_2023\",\n              \"name\": \"Cricket\"\n            },\n            {\n              \"id\": \"it_2262\",\n              \"name\": \"Freelance\"\n            },\n            {\n              \"id\": \"it_2389\",\n              \"name\": \"Skateboarding\"\n            },\n            {\n              \"id\": \"it_2268\",\n              \"name\": \"Gospel\"\n            },\n            {\n              \"id\": \"it_27\",\n              \"name\": \"K-Pop\"\n            },\n            {\n              \"id\": \"it_2027\",\n              \"name\": \"Potterhead\"\n            },\n            {\n              \"id\": \"it_26\",\n              \"name\": \"Trying new things\"\n            },\n            {\n              \"id\": \"it_29\",\n              \"name\": \"Photography\"\n            },\n            {\n              \"id\": \"it_2024\",\n              \"name\": \"Bollywood\"\n            },\n            {\n              \"id\": \"it_28\",\n              \"name\": \"Reading\"\n            },\n            {\n              \"id\": \"it_2388\",\n              \"name\": \"Singing\"\n            },\n            {\n              \"id\": \"it_23\",\n              \"name\": \"Sports\"\n            },\n            {\n              \"id\": \"it_2028\",\n              \"name\": \"Poetry\"\n            },\n            {\n              \"id\": \"it_2029\",\n              \"name\": \"Stand-up comedy\"\n            },\n            {\n              \"id\": \"it_1\",\n              \"name\": \"Coffee\"\n            },\n            {\n              \"id\": \"it_3\",\n              \"name\": \"Karaoke\"\n            },\n            {\n              \"id\": \"it_2260\",\n              \"name\": \"Fortnite\"\n            },\n            {\n              \"id\": \"it_2261\",\n              \"name\": \"Free diving\"\n            },\n            {\n              \"id\": \"it_2382\",\n              \"name\": \"Self-development\"\n            },\n            {\n              \"id\": \"it_2055\",\n              \"name\": \"Mental health awareness\"\n            },\n            {\n              \"id\": \"it_19\",\n              \"name\": \"Foodie tour\"\n            },\n            {\n              \"id\": \"it_2053\",\n              \"name\": \"Voter rights\"\n            },\n            {\n              \"id\": \"it_2295\",\n              \"name\": \"Jiu-jitsu\"\n            },\n            {\n              \"id\": \"it_2054\",\n              \"name\": \"Climate change\"\n            },\n            {\n              \"id\": \"it_16\",\n              \"name\": \"Exhibition\"\n            },\n            {\n              \"id\": \"it_15\",\n              \"name\": \"Walking my dog\"\n            },\n            {\n              \"id\": \"it_2057\",\n              \"name\": \"LGBTQIA+ rights\"\n            },\n            {\n              \"id\": \"it_2058\",\n              \"name\": \"Feminism\"\n            },\n            {\n              \"id\": \"it_12\",\n              \"name\": \"VR room\"\n            },\n            {\n              \"id\": \"it_11\",\n              \"name\": \"Escape café\"\n            },\n            {\n              \"id\": \"it_14\",\n              \"name\": \"Shopping\"\n            },\n            {\n              \"id\": \"it_10\",\n              \"name\": \"Brunch\"\n            },\n            {\n              \"id\": \"it_2290\",\n              \"name\": \"Investment\"\n            },\n            {\n              \"id\": \"it_2293\",\n              \"name\": \"Jet skiing\"\n            },\n            {\n              \"id\": \"it_2172\",\n              \"name\": \"Reggaeton\"\n            },\n            {\n              \"id\": \"it_2051\",\n              \"name\": \"Vintage clothing\"\n            },\n            {\n              \"id\": \"it_2052\",\n              \"name\": \"Black Lives Matter\"\n            },\n            {\n              \"id\": \"it_2294\",\n              \"name\": \"Jogging\"\n            },\n            {\n              \"id\": \"it_2050\",\n              \"name\": \"Road trips\"\n            },\n            {\n              \"id\": \"it_2171\",\n              \"name\": \"Vintage fashion\"\n            },\n            {\n              \"id\": \"it_2165\",\n              \"name\": \"Voguing\"\n            },\n            {\n              \"id\": \"it_2166\",\n              \"name\": \"Sofa surfing\"\n            },\n            {\n              \"id\": \"it_2163\",\n              \"name\": \"Happy hour\"\n            },\n            {\n              \"id\": \"it_2285\",\n              \"name\": \"Inclusivity\"\n            },\n            {\n              \"id\": \"it_2048\",\n              \"name\": \"Country music\"\n            },\n            {\n              \"id\": \"it_2049\",\n              \"name\": \"Football\"\n            },\n            {\n              \"id\": \"it_2288\",\n              \"name\": \"Rollerblading\"\n            },\n            {\n              \"id\": \"it_2289\",\n              \"name\": \"Investing\"\n            },\n            {\n              \"id\": \"it_2161\",\n              \"name\": \"Tennis\"\n            },\n            {\n              \"id\": \"it_2282\",\n              \"name\": \"Ice cream\"\n            },\n            {\n              \"id\": \"it_2283\",\n              \"name\": \"Ice skating\"\n            },\n            {\n              \"id\": \"it_2280\",\n              \"name\": \"Human rights\"\n            },\n            {\n              \"id\": \"it_2160\",\n              \"name\": \"Exhibitions\"\n            },\n            {\n              \"id\": \"it_2352\",\n              \"name\": \"Pig roast\"\n            },\n            {\n              \"id\": \"it_1021\",\n              \"name\": \"Skiing\"\n            },\n            {\n              \"id\": \"it_2232\",\n              \"name\": \"Canoeing\"\n            },\n            {\n              \"id\": \"it_2111\",\n              \"name\": \"West End musicals\"\n            },\n            {\n              \"id\": \"it_1022\",\n              \"name\": \"Snowboarding\"\n            },\n            {\n              \"id\": \"it_2353\",\n              \"name\": \"Pilates\"\n            },\n            {\n              \"id\": \"it_2351\",\n              \"name\": \"Pentathlon\"\n            },\n            {\n              \"id\": \"it_2230\",\n              \"name\": \"Broadway\"\n            },\n            {\n              \"id\": \"it_2356\",\n              \"name\": \"PlayStation\"\n            },\n            {\n              \"id\": \"it_2235\",\n              \"name\": \"Cheerleading\"\n            },\n            {\n              \"id\": \"it_2236\",\n              \"name\": \"Choir\"\n            },\n            {\n              \"id\": \"it_2357\",\n              \"name\": \"Pole dancing\"\n            },\n            {\n              \"id\": \"it_2115\",\n              \"name\": \"Five-a-side football\"\n            },\n            {\n              \"id\": \"it_2233\",\n              \"name\": \"Car racing\"\n            },\n            {\n              \"id\": \"it_2354\",\n              \"name\": \"Pinterest\"\n            },\n            {\n              \"id\": \"it_2113\",\n              \"name\": \"Pub quiz\"\n            },\n            {\n              \"id\": \"it_1024\",\n              \"name\": \"Festivals\"\n            },\n            {\n              \"id\": \"it_2234\",\n              \"name\": \"Catan\"\n            },\n            {\n              \"id\": \"it_2239\",\n              \"name\": \"Cosplay\"\n            },\n            {\n              \"id\": \"it_2119\",\n              \"name\": \"Motor sports\"\n            },\n            {\n              \"id\": \"it_2237\",\n              \"name\": \"Coffee stands\"\n            },\n            {\n              \"id\": \"it_2238\",\n              \"name\": \"Content creation\"\n            },\n            {\n              \"id\": \"it_2117\",\n              \"name\": \"E-sports\"\n            },\n            {\n              \"id\": \"it_2220\",\n              \"name\": \"Bicycle racing\"\n            },\n            {\n              \"id\": \"it_2221\",\n              \"name\": \"Binge-watching TV series\"\n            },\n            {\n              \"id\": \"it_1011\",\n              \"name\": \"Songwriter\"\n            },\n            {\n              \"id\": \"it_2224\",\n              \"name\": \"Bodycombat\"\n            },\n            {\n              \"id\": \"it_1014\",\n              \"name\": \"Tattoos\"\n            },\n            {\n              \"id\": \"it_2346\",\n              \"name\": \"Painting\"\n            },\n            {\n              \"id\": \"it_2225\",\n              \"name\": \"Bodyjam\"\n            },\n            {\n              \"id\": \"it_2343\",\n              \"name\": \"Paddle boarding\"\n            },\n            {\n              \"id\": \"it_2344\",\n              \"name\": \"Padel\"\n            },\n            {\n              \"id\": \"it_2223\",\n              \"name\": \"Blackpink\"\n            },\n            {\n              \"id\": \"it_1013\",\n              \"name\": \"Surfing\"\n            },\n            {\n              \"id\": \"it_2228\",\n              \"name\": \"Bowling\"\n            },\n            {\n              \"id\": \"it_2107\",\n              \"name\": \"Grime\"\n            },\n            {\n              \"id\": \"it_2108\",\n              \"name\": \"’90s Britpop\"\n            },\n            {\n              \"id\": \"it_2226\",\n              \"name\": \"Bodypump\"\n            },\n            {\n              \"id\": \"it_2106\",\n              \"name\": \"Beach bars\"\n            },\n            {\n              \"id\": \"it_2227\",\n              \"name\": \"Bodystep\"\n            },\n            {\n              \"id\": \"it_2348\",\n              \"name\": \"Paragliding\"\n            },\n            {\n              \"id\": \"it_2109\",\n              \"name\": \"Upcycling\"\n            },\n            {\n              \"id\": \"it_2253\",\n              \"name\": \"Equality\"\n            },\n            {\n              \"id\": \"it_2011\",\n              \"name\": \"Astrology\"\n            },\n            {\n              \"id\": \"it_2133\",\n              \"name\": \"Motorcycles\"\n            },\n            {\n              \"id\": \"it_2254\",\n              \"name\": \"Equestrian\"\n            },\n            {\n              \"id\": \"it_2251\",\n              \"name\": \"Entrepreneurship\"\n            },\n            {\n              \"id\": \"it_2372\",\n              \"name\": \"Sake\"\n            },\n            {\n              \"id\": \"it_2131\",\n              \"name\": \"BTS\"\n            },\n            {\n              \"id\": \"it_2010\",\n              \"name\": \"Cooking\"\n            },\n            {\n              \"id\": \"it_2252\",\n              \"name\": \"Environmental protection\"\n            },\n            {\n              \"id\": \"it_2257\",\n              \"name\": \"Fencing\"\n            },\n            {\n              \"id\": \"it_2015\",\n              \"name\": \"Football\"\n            },\n            {\n              \"id\": \"it_2378\",\n              \"name\": \"Saxophonist\"\n            },\n            {\n              \"id\": \"it_2379\",\n              \"name\": \"Sci-fi\"\n            },\n            {\n              \"id\": \"it_2016\",\n              \"name\": \"Dancing\"\n            },\n            {\n              \"id\": \"it_2258\",\n              \"name\": \"Film festivals\"\n            },\n            {\n              \"id\": \"it_2013\",\n              \"name\": \"Gardening\"\n            },\n            {\n              \"id\": \"it_2135\",\n              \"name\": \"Amateur cook\"\n            },\n            {\n              \"id\": \"it_2256\",\n              \"name\": \"Exchange programmes\"\n            },\n            {\n              \"id\": \"it_2377\",\n              \"name\": \"Sauna\"\n            },\n            {\n              \"id\": \"it_2014\",\n              \"name\": \"Art\"\n            },\n            {\n              \"id\": \"it_2019\",\n              \"name\": \"Politics\"\n            },\n            {\n              \"id\": \"it_2259\",\n              \"name\": \"Flamenco\"\n            },\n            {\n              \"id\": \"it_2017\",\n              \"name\": \"Museum\"\n            },\n            {\n              \"id\": \"it_2018\",\n              \"name\": \"Activism\"\n            },\n            {\n              \"id\": \"it_2242\",\n              \"name\": \"DAOs\"\n            },\n            {\n              \"id\": \"it_2363\",\n              \"name\": \"Real estate\"\n            },\n            {\n              \"id\": \"it_2121\",\n              \"name\": \"Podcasts\"\n            },\n            {\n              \"id\": \"it_2243\",\n              \"name\": \"Disability rights\"\n            },\n            {\n              \"id\": \"it_2362\",\n              \"name\": \"Rave\"\n            },\n            {\n              \"id\": \"it_2120\",\n              \"name\": \"Pimms\"\n            },\n            {\n              \"id\": \"it_2246\",\n              \"name\": \"Drive-in cinema\"\n            },\n            {\n              \"id\": \"it_2367\",\n              \"name\": \"Rock climbing\"\n            },\n            {\n              \"id\": \"it_2125\",\n              \"name\": \"BBQ\"\n            },\n            {\n              \"id\": \"it_2004\",\n              \"name\": \"Craft beer\"\n            },\n            {\n              \"id\": \"it_2126\",\n              \"name\": \"Iced tea\"\n            },\n            {\n              \"id\": \"it_2247\",\n              \"name\": \"Drummer\"\n            },\n            {\n              \"id\": \"it_2005\",\n              \"name\": \"Tea\"\n            },\n            {\n              \"id\": \"it_2002\",\n              \"name\": \"Board games\"\n            },\n            {\n              \"id\": \"it_2365\",\n              \"name\": \"Roblox\"\n            },\n            {\n              \"id\": \"it_2123\",\n              \"name\": \"Pubs\"\n            },\n            {\n              \"id\": \"it_2366\",\n              \"name\": \"Rock\"\n            },\n            {\n              \"id\": \"it_2124\",\n              \"name\": \"Tango\"\n            },\n            {\n              \"id\": \"it_2245\",\n              \"name\": \"Drawing\"\n            },\n            {\n              \"id\": \"it_2003\",\n              \"name\": \"Trivia\"\n            },\n            {\n              \"id\": \"it_2129\",\n              \"name\": \"Pho\"\n            },\n            {\n              \"id\": \"it_2008\",\n              \"name\": \"Volunteering\"\n            },\n            {\n              \"id\": \"it_2009\",\n              \"name\": \"Environmentalism\"\n            },\n            {\n              \"id\": \"it_2369\",\n              \"name\": \"Rollerskating\"\n            },\n            {\n              \"id\": \"it_2006\",\n              \"name\": \"Wine\"\n            },\n            {\n              \"id\": \"it_2248\",\n              \"name\": \"Dungeons & Dragons\"\n            },\n            {\n              \"id\": \"it_2007\",\n              \"name\": \"Vlogging\"\n            },\n            {\n              \"id\": \"it_2249\",\n              \"name\": \"Electronic music\"\n            },\n            {\n              \"id\": \"it_2360\",\n              \"name\": \"Ramen\"\n            },\n            {\n              \"id\": \"it_2430\",\n              \"name\": \"Weightlifting\"\n            },\n            {\n              \"id\": \"it_2312\",\n              \"name\": \"Live music\"\n            },\n            {\n              \"id\": \"it_2433\",\n              \"name\": \"Writing\"\n            },\n            {\n              \"id\": \"it_2434\",\n              \"name\": \"Xbox\"\n            },\n            {\n              \"id\": \"it_2431\",\n              \"name\": \"World peace\"\n            },\n            {\n              \"id\": \"it_2432\",\n              \"name\": \"Wrestling\"\n            },\n            {\n              \"id\": \"it_2311\",\n              \"name\": \"Literature\"\n            },\n            {\n              \"id\": \"it_2316\",\n              \"name\": \"Manga\"\n            },\n            {\n              \"id\": \"it_2437\",\n              \"name\": \"Pride\"\n            },\n            {\n              \"id\": \"it_2317\",\n              \"name\": \"Marathon\"\n            },\n            {\n              \"id\": \"it_2314\",\n              \"name\": \"Make-up\"\n            },\n            {\n              \"id\": \"it_2435\",\n              \"name\": \"Youth empowerment\"\n            },\n            {\n              \"id\": \"it_2436\",\n              \"name\": \"YouTube\"\n            },\n            {\n              \"id\": \"it_2318\",\n              \"name\": \"Martial arts\"\n            },\n            {\n              \"id\": \"it_2319\",\n              \"name\": \"Marvel\"\n            },\n            {\n              \"id\": \"it_5020\",\n              \"name\": \"Luge\"\n            },\n            {\n              \"id\": \"it_5021\",\n              \"name\": \"Ice hockey\"\n            },\n            {\n              \"id\": \"it_5016\",\n              \"name\": \"Taekwondo\"\n            },\n            {\n              \"id\": \"it_5017\",\n              \"name\": \"Trampolining\"\n            },\n            {\n              \"id\": \"it_5018\",\n              \"name\": \"Water polo\"\n            },\n            {\n              \"id\": \"it_5012\",\n              \"name\": \"Rhythmic gymnastics\"\n            },\n            {\n              \"id\": \"it_2422\",\n              \"name\": \"Vegan cooking\"\n            },\n            {\n              \"id\": \"it_5013\",\n              \"name\": \"Rowing\"\n            },\n            {\n              \"id\": \"it_2423\",\n              \"name\": \"Vermouth\"\n            },\n            {\n              \"id\": \"it_2302\",\n              \"name\": \"Korean food\"\n            },\n            {\n              \"id\": \"it_5014\",\n              \"name\": \"Sports shooting\"\n            },\n            {\n              \"id\": \"it_2420\",\n              \"name\": \"Twitter\"\n            },\n            {\n              \"id\": \"it_5015\",\n              \"name\": \"Squash\"\n            },\n            {\n              \"id\": \"it_2426\",\n              \"name\": \"Volleyball\"\n            },\n            {\n              \"id\": \"it_2427\",\n              \"name\": \"Walking tours\"\n            },\n            {\n              \"id\": \"it_2424\",\n              \"name\": \"Vinyasa\"\n            },\n            {\n              \"id\": \"it_2425\",\n              \"name\": \"Virtual reality\"\n            },\n            {\n              \"id\": \"it_2309\",\n              \"name\": \"League of Legends\"\n            },\n            {\n              \"id\": \"it_5010\",\n              \"name\": \"Karate\"\n            },\n            {\n              \"id\": \"it_5011\",\n              \"name\": \"Lacrosse\"\n            },\n            {\n              \"id\": \"it_2334\",\n              \"name\": \"NFTs\"\n            },\n            {\n              \"id\": \"it_2213\",\n              \"name\": \"Pub crawls\"\n            },\n            {\n              \"id\": \"it_2335\",\n              \"name\": \"Nintendo\"\n            },\n            {\n              \"id\": \"it_2214\",\n              \"name\": \"Baseball\"\n            },\n            {\n              \"id\": \"it_1001\",\n              \"name\": \"Parties\"\n            },\n            {\n              \"id\": \"it_2211\",\n              \"name\": \"Ballet\"\n            },\n            {\n              \"id\": \"it_2212\",\n              \"name\": \"Bands\"\n            },\n            {\n              \"id\": \"it_2338\",\n              \"name\": \"Online games\"\n            },\n            {\n              \"id\": \"it_2217\",\n              \"name\": \"Battle Ground\"\n            },\n            {\n              \"id\": \"it_2218\",\n              \"name\": \"Beach tennis\"\n            },\n            {\n              \"id\": \"it_99\",\n              \"name\": \"Nightlife\"\n            },\n            {\n              \"id\": \"it_2339\",\n              \"name\": \"Online shopping\"\n            },\n            {\n              \"id\": \"it_1005\",\n              \"name\": \"Sailing\"\n            },\n            {\n              \"id\": \"it_2215\",\n              \"name\": \"Bassist\"\n            },\n            {\n              \"id\": \"it_2337\",\n              \"name\": \"Online broker\"\n            },\n            {\n              \"id\": \"it_94\",\n              \"name\": \"Military\"\n            },\n            {\n              \"id\": \"it_2320\",\n              \"name\": \"Memes\"\n            },\n            {\n              \"id\": \"it_2202\",\n              \"name\": \"Among Us\"\n            },\n            {\n              \"id\": \"it_2323\",\n              \"name\": \"Motorbike racing\"\n            },\n            {\n              \"id\": \"it_5155\",\n              \"name\": \"Muay Thai\"\n            },\n            {\n              \"id\": \"it_2324\",\n              \"name\": \"Motorcycling\"\n            },\n            {\n              \"id\": \"it_2321\",\n              \"name\": \"Metaverse\"\n            },\n            {\n              \"id\": \"it_2322\",\n              \"name\": \"Mindfulness\"\n            },\n            {\n              \"id\": \"it_2201\",\n              \"name\": \"Acapella\"\n            },\n            {\n              \"id\": \"it_2327\",\n              \"name\": \"Playing a musical instrument\"\n            },\n            {\n              \"id\": \"it_2206\",\n              \"name\": \"Art galleries\"\n            },\n            {\n              \"id\": \"it_2328\",\n              \"name\": \"Writing musicals\"\n            },\n            {\n              \"id\": \"it_88\",\n              \"name\": \"Hiking\"\n            },\n            {\n              \"id\": \"it_2207\",\n              \"name\": \"Artistic gymnastics\"\n            },\n            {\n              \"id\": \"it_2325\",\n              \"name\": \"Mountains\"\n            },\n            {\n              \"id\": \"it_2205\",\n              \"name\": \"Archery\"\n            },\n            {\n              \"id\": \"it_2208\",\n              \"name\": \"Atari\"\n            },\n            {\n              \"id\": \"it_2209\",\n              \"name\": \"Backpacking\"\n            },\n            {\n              \"id\": \"it_86\",\n              \"name\": \"Fishing\"\n            },\n            {\n              \"id\": \"it_2075\",\n              \"name\": \"Clubbing\"\n            },\n            {\n              \"id\": \"it_2079\",\n              \"name\": \"Street food\"\n            },\n            {\n              \"id\": \"it_78\",\n              \"name\": \"Crossfit\"\n            },\n            {\n              \"id\": \"it_76\",\n              \"name\": \"Concerts\"\n            },\n            {\n              \"id\": \"it_75\",\n              \"name\": \"Climbing\"\n            },\n            {\n              \"id\": \"it_70\",\n              \"name\": \"Baking\"\n            },\n            {\n              \"id\": \"it_72\",\n              \"name\": \"Camping\"\n            },\n            {\n              \"id\": \"it_71\",\n              \"name\": \"Blogging\"\n            },\n            {\n              \"id\": \"it_2070\",\n              \"name\": \"Collecting\"\n            },\n            {\n              \"id\": \"it_2072\",\n              \"name\": \"Cars\"\n            },\n            {\n              \"id\": \"it_2066\",\n              \"name\": \"Start-ups\"\n            },\n            {\n              \"id\": \"it_2067\",\n              \"name\": \"Boba tea\"\n            },\n            {\n              \"id\": \"it_2064\",\n              \"name\": \"High-school baseketball league (TW)\"\n            },\n            {\n              \"id\": \"it_2069\",\n              \"name\": \"Badminton\"\n            },\n            {\n              \"id\": \"it_66\",\n              \"name\": \"Active lifestyle\"\n            },\n            {\n              \"id\": \"it_63\",\n              \"name\": \"Fashion\"\n            },\n            {\n              \"id\": \"it_62\",\n              \"name\": \"Anime\"\n            },\n            {\n              \"id\": \"it_2062\",\n              \"name\": \"NBA\"\n            },\n            {\n              \"id\": \"it_2063\",\n              \"name\": \"MLB\"\n            },\n            {\n              \"id\": \"it_2099\",\n              \"name\": \"Funk music\"\n            },\n            {\n              \"id\": \"it_5006\",\n              \"name\": \"Diving\"\n            },\n            {\n              \"id\": \"it_2097\",\n              \"name\": \"Caipirinha\"\n            },\n            {\n              \"id\": \"it_5007\",\n              \"name\": \"American flag football\"\n            },\n            {\n              \"id\": \"it_5008\",\n              \"name\": \"Handball\"\n            },\n            {\n              \"id\": \"it_5001\",\n              \"name\": \"Artistic swimming\"\n            },\n            {\n              \"id\": \"it_5002\",\n              \"name\": \"Athletics\"\n            },\n            {\n              \"id\": \"it_59\",\n              \"name\": \"Indoor activities\"\n            },\n            {\n              \"id\": \"it_5003\",\n              \"name\": \"Softball\"\n            },\n            {\n              \"id\": \"it_5004\",\n              \"name\": \"Beach volleyball\"\n            },\n            {\n              \"id\": \"it_2410\",\n              \"name\": \"Tempeh\"\n            },\n            {\n              \"id\": \"it_56\",\n              \"name\": \"DIY\"\n            },\n            {\n              \"id\": \"it_2416\",\n              \"name\": \"Town festivities\"\n            },\n            {\n              \"id\": \"it_55\",\n              \"name\": \"Cycling\"\n            },\n            {\n              \"id\": \"it_58\",\n              \"name\": \"Outdoors\"\n            },\n            {\n              \"id\": \"it_2414\",\n              \"name\": \"TikTok\"\n            },\n            {\n              \"id\": \"it_57\",\n              \"name\": \"Picnicking\"\n            },\n            {\n              \"id\": \"it_2419\",\n              \"name\": \"Twitch\"\n            },\n            {\n              \"id\": \"it_5009\",\n              \"name\": \"Judo\"\n            },\n            {\n              \"id\": \"it_51\",\n              \"name\": \"Comedy\"\n            },\n            {\n              \"id\": \"it_2417\",\n              \"name\": \"Trap music\"\n            },\n            {\n              \"id\": \"it_54\",\n              \"name\": \"Music\"\n            },\n            {\n              \"id\": \"it_2418\",\n              \"name\": \"Triathlon\"\n            },\n            {\n              \"id\": \"it_53\",\n              \"name\": \"Netflix\"\n            },\n            {\n              \"id\": \"it_50\",\n              \"name\": \"Disney\"\n            },\n            {\n              \"id\": \"it_2090\",\n              \"name\": \"Rugby\"\n            },\n            {\n              \"id\": \"it_2095\",\n              \"name\": \"Açaí\"\n            },\n            {\n              \"id\": \"it_2093\",\n              \"name\": \"Samba\"\n            },\n            {\n              \"id\": \"it_2094\",\n              \"name\": \"Tarot\"\n            },\n            {\n              \"id\": \"it_2400\",\n              \"name\": \"Stock exchange\"\n            },\n            {\n              \"id\": \"it_2401\",\n              \"name\": \"Stocks\"\n            },\n            {\n              \"id\": \"it_48\",\n              \"name\": \"Swimming\"\n            },\n            {\n              \"id\": \"it_2404\",\n              \"name\": \"Table tennis\"\n            },\n            {\n              \"id\": \"it_41\",\n              \"name\": \"Killing time\"\n            },\n            {\n              \"id\": \"it_43\",\n              \"name\": \"Working out\"\n            },\n            {\n              \"id\": \"it_42\",\n              \"name\": \"Yoga\"\n            },\n            {\n              \"id\": \"it_2080\",\n              \"name\": \"Horror films\"\n            },\n            {\n              \"id\": \"it_2081\",\n              \"name\": \"Boxing\"\n            },\n            {\n              \"id\": \"it_2082\",\n              \"name\": \"Chilling at a bar\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/language@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/language@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/language@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/language@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"minSelections\": 3,\n          \"maxSelections\": 5,\n          \"backgroundText\": \"Add interests\",\n          \"searchBackgroundText\": \"Search interests\",\n          \"sectionId\": 2,\n          \"sectionName\": \"Interests\",\n          \"matchGroupKey\": \"languages\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": false\n        }\n      ]", new System.Text.Json.JsonDocumentOptions()));

            migrationBuilder.UpdateData(
                table: "AvailableDescriptors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Descriptors",
                value: System.Text.Json.JsonDocument.Parse("[\n        {\n          \"id\": \"de_29\",\n          \"name\": \"Looking for\",\n          \"prompt\": \"What are you looking for?\",\n          \"type\": \"choice_selector_v1\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Long-term partner\",\n              \"style\": \"purple\",\n              \"emoji\": \"💘\",\n              \"iconUrls\": [\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_cupid@1x.png\",\n                  \"quality\": \"1x\",\n                  \"width\": 50,\n                  \"height\": 50\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_cupid@2x.png\",\n                  \"quality\": \"2x\",\n                  \"width\": 100,\n                  \"height\": 100\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_cupid@3x.png\",\n                  \"quality\": \"3x\",\n                  \"width\": 150,\n                  \"height\": 150\n                }\n              ],\n              \"matchGroupKey\": \"Serious\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Long-term, but short-term OK\",\n              \"style\": \"pink\",\n              \"emoji\": \"😍\",\n              \"iconUrls\": [\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_heart_eyes@1x.png\",\n                  \"quality\": \"1x\",\n                  \"width\": 50,\n                  \"height\": 50\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_heart_eyes@2x.png\",\n                  \"quality\": \"2x\",\n                  \"width\": 100,\n                  \"height\": 100\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_heart_eyes@3x.png\",\n                  \"quality\": \"3x\",\n                  \"width\": 150,\n                  \"height\": 150\n                }\n              ]\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Short-term, but long-term OK\",\n              \"style\": \"yellow\",\n              \"emoji\": \"🥂\",\n              \"iconUrls\": [\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_clinking_glasses@1x.png\",\n                  \"quality\": \"1x\",\n                  \"width\": 50,\n                  \"height\": 50\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_clinking_glasses@2x.png\",\n                  \"quality\": \"2x\",\n                  \"width\": 100,\n                  \"height\": 100\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_clinking_glasses@3x.png\",\n                  \"quality\": \"3x\",\n                  \"width\": 150,\n                  \"height\": 150\n                }\n              ]\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"Short-term fun\",\n              \"style\": \"green\",\n              \"emoji\": \"🎉\",\n              \"iconUrls\": [\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_tada@1x.png\",\n                  \"quality\": \"1x\",\n                  \"width\": 50,\n                  \"height\": 50\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_tada@2x.png\",\n                  \"quality\": \"2x\",\n                  \"width\": 100,\n                  \"height\": 100\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_tada@3x.png\",\n                  \"quality\": \"3x\",\n                  \"width\": 150,\n                  \"height\": 150\n                }\n              ],\n              \"matchGroupKey\": \"Casual\"\n            },\n            {\n              \"id\": \"5\",\n              \"name\": \"New friends\",\n              \"style\": \"teal\",\n              \"emoji\": \"👋\",\n              \"iconUrls\": [\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_wave@1x.png\",\n                  \"quality\": \"1x\",\n                  \"width\": 50,\n                  \"height\": 50\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_wave@2x.png\",\n                  \"quality\": \"2x\",\n                  \"width\": 100,\n                  \"height\": 100\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_wave@3x.png\",\n                  \"quality\": \"3x\",\n                  \"width\": 150,\n                  \"height\": 150\n                }\n              ],\n              \"matchGroupKey\": \"Friends\"\n            },\n            {\n              \"id\": \"6\",\n              \"name\": \"Still figuring it out\",\n              \"style\": \"blue\",\n              \"emoji\": \"🤔\",\n              \"iconUrls\": [\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_thinking_face@1x.png\",\n                  \"quality\": \"1x\",\n                  \"width\": 50,\n                  \"height\": 50\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_thinking_face@2x.png\",\n                  \"quality\": \"2x\",\n                  \"width\": 100,\n                  \"height\": 100\n                },\n                {\n                  \"url\": \"https://static-assets.gotinder.com/icons/descriptors/relationship_intent_thinking_face@3x.png\",\n                  \"quality\": \"3x\",\n                  \"width\": 150,\n                  \"height\": 150\n                }\n              ],\n              \"matchGroupKey\": \"DontKnow\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/looking_for@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/looking_for@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/looking_for@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/looking_for@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"subPrompt\": \"All good if it changes. There’s something for everyone.\",\n          \"sectionId\": 3,\n          \"sectionName\": \"Relationship Goals\",\n          \"matchGroupKey\": \"intent\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        }\n      ]", new System.Text.Json.JsonDocumentOptions()));

            migrationBuilder.UpdateData(
                table: "AvailableDescriptors",
                keyColumn: "Id",
                keyValue: 4,
                column: "Descriptors",
                value: System.Text.Json.JsonDocument.Parse("[\n        {\n          \"id\": \"de_37\",\n          \"type\": \"multiSelectionSet\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Afrikaans\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Albanian\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Amharic\"\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"Arabic\",\n              \"matchGroupKey\": \"Arabic\"\n            },\n            {\n              \"id\": \"5\",\n              \"name\": \"Armenian\",\n              \"matchGroupKey\": \"Armenian\"\n            },\n            {\n              \"id\": \"133\",\n              \"name\": \"ASL\"\n            },\n            {\n              \"id\": \"6\",\n              \"name\": \"Assamese\"\n            },\n            {\n              \"id\": \"7\",\n              \"name\": \"Aymara\"\n            },\n            {\n              \"id\": \"8\",\n              \"name\": \"Azerbaijani\"\n            },\n            {\n              \"id\": \"9\",\n              \"name\": \"Bambara\"\n            },\n            {\n              \"id\": \"10\",\n              \"name\": \"Basque\"\n            },\n            {\n              \"id\": \"11\",\n              \"name\": \"Belarusian\"\n            },\n            {\n              \"id\": \"12\",\n              \"name\": \"Bengali\",\n              \"matchGroupKey\": \"Bengali\"\n            },\n            {\n              \"id\": \"13\",\n              \"name\": \"Bhojpuri\"\n            },\n            {\n              \"id\": \"14\",\n              \"name\": \"Bosnian\"\n            },\n            {\n              \"id\": \"134\",\n              \"name\": \"Breton\"\n            },\n            {\n              \"id\": \"15\",\n              \"name\": \"Bulgarian\",\n              \"matchGroupKey\": \"Bulgarian\"\n            },\n            {\n              \"id\": \"16\",\n              \"name\": \"Burmese\"\n            },\n            {\n              \"id\": \"17\",\n              \"name\": \"Cantonese\",\n              \"matchGroupKey\": \"Cantonese\"\n            },\n            {\n              \"id\": \"18\",\n              \"name\": \"Catalan\"\n            },\n            {\n              \"id\": \"19\",\n              \"name\": \"Cebuano\"\n            },\n            {\n              \"id\": \"20\",\n              \"name\": \"Chichewa\"\n            },\n            {\n              \"id\": \"21\",\n              \"name\": \"Corsican\"\n            },\n            {\n              \"id\": \"22\",\n              \"name\": \"Croatian\"\n            },\n            {\n              \"id\": \"23\",\n              \"name\": \"Czech\",\n              \"matchGroupKey\": \"Czech\"\n            },\n            {\n              \"id\": \"24\",\n              \"name\": \"Danish\",\n              \"matchGroupKey\": \"Danish\"\n            },\n            {\n              \"id\": \"25\",\n              \"name\": \"Dhivehi\"\n            },\n            {\n              \"id\": \"26\",\n              \"name\": \"Dogri\"\n            },\n            {\n              \"id\": \"27\",\n              \"name\": \"Dutch\",\n              \"matchGroupKey\": \"Dutch\"\n            },\n            {\n              \"id\": \"28\",\n              \"name\": \"English\",\n              \"matchGroupKey\": \"English\"\n            },\n            {\n              \"id\": \"29\",\n              \"name\": \"Esperanto\"\n            },\n            {\n              \"id\": \"30\",\n              \"name\": \"Estonian\"\n            },\n            {\n              \"id\": \"31\",\n              \"name\": \"Ewe\"\n            },\n            {\n              \"id\": \"32\",\n              \"name\": \"Filipino\"\n            },\n            {\n              \"id\": \"33\",\n              \"name\": \"Finnish\",\n              \"matchGroupKey\": \"Finnish\"\n            },\n            {\n              \"id\": \"34\",\n              \"name\": \"French\",\n              \"matchGroupKey\": \"French\"\n            },\n            {\n              \"id\": \"35\",\n              \"name\": \"Frisian\"\n            },\n            {\n              \"id\": \"36\",\n              \"name\": \"Galician\"\n            },\n            {\n              \"id\": \"37\",\n              \"name\": \"Georgian\"\n            },\n            {\n              \"id\": \"38\",\n              \"name\": \"German\",\n              \"matchGroupKey\": \"German\"\n            },\n            {\n              \"id\": \"39\",\n              \"name\": \"Greek\",\n              \"matchGroupKey\": \"Greek\"\n            },\n            {\n              \"id\": \"40\",\n              \"name\": \"Guaraní\"\n            },\n            {\n              \"id\": \"41\",\n              \"name\": \"Gujarati\",\n              \"matchGroupKey\": \"Gujarati\"\n            },\n            {\n              \"id\": \"42\",\n              \"name\": \"Haitian Creole\"\n            },\n            {\n              \"id\": \"43\",\n              \"name\": \"Hausa\"\n            },\n            {\n              \"id\": \"44\",\n              \"name\": \"Hawaiian\"\n            },\n            {\n              \"id\": \"45\",\n              \"name\": \"Hebrew\",\n              \"matchGroupKey\": \"Hebrew\"\n            },\n            {\n              \"id\": \"46\",\n              \"name\": \"Hindi\",\n              \"matchGroupKey\": \"Hindi\"\n            },\n            {\n              \"id\": \"47\",\n              \"name\": \"Hmong\"\n            },\n            {\n              \"id\": \"48\",\n              \"name\": \"Hungarian\",\n              \"matchGroupKey\": \"Hungarian\"\n            },\n            {\n              \"id\": \"49\",\n              \"name\": \"Icelandic\"\n            },\n            {\n              \"id\": \"50\",\n              \"name\": \"Igbo\"\n            },\n            {\n              \"id\": \"51\",\n              \"name\": \"Ilocano\"\n            },\n            {\n              \"id\": \"52\",\n              \"name\": \"Indonesian\",\n              \"matchGroupKey\": \"Indonesian\"\n            },\n            {\n              \"id\": \"53\",\n              \"name\": \"Irish\",\n              \"matchGroupKey\": \"Irish\"\n            },\n            {\n              \"id\": \"54\",\n              \"name\": \"Italian\",\n              \"matchGroupKey\": \"Italian\"\n            },\n            {\n              \"id\": \"55\",\n              \"name\": \"Japanese\",\n              \"matchGroupKey\": \"Japanese\"\n            },\n            {\n              \"id\": \"56\",\n              \"name\": \"Javanese\"\n            },\n            {\n              \"id\": \"57\",\n              \"name\": \"Kannada\"\n            },\n            {\n              \"id\": \"58\",\n              \"name\": \"Kazakh\"\n            },\n            {\n              \"id\": \"59\",\n              \"name\": \"Khmer\",\n              \"matchGroupKey\": \"Khmer\"\n            },\n            {\n              \"id\": \"60\",\n              \"name\": \"Kinyarwanda\"\n            },\n            {\n              \"id\": \"61\",\n              \"name\": \"Konkani\"\n            },\n            {\n              \"id\": \"62\",\n              \"name\": \"Korean\",\n              \"matchGroupKey\": \"Korean\"\n            },\n            {\n              \"id\": \"63\",\n              \"name\": \"Krio\"\n            },\n            {\n              \"id\": \"64\",\n              \"name\": \"Kurdish\"\n            },\n            {\n              \"id\": \"65\",\n              \"name\": \"Kyrgyz\"\n            },\n            {\n              \"id\": \"66\",\n              \"name\": \"Lao\"\n            },\n            {\n              \"id\": \"67\",\n              \"name\": \"Latin\"\n            },\n            {\n              \"id\": \"68\",\n              \"name\": \"Latvian\",\n              \"matchGroupKey\": \"Latvian\"\n            },\n            {\n              \"id\": \"69\",\n              \"name\": \"Lingala\"\n            },\n            {\n              \"id\": \"70\",\n              \"name\": \"Lithuanian\",\n              \"matchGroupKey\": \"Lithuanian\"\n            },\n            {\n              \"id\": \"71\",\n              \"name\": \"Luganda\"\n            },\n            {\n              \"id\": \"72\",\n              \"name\": \"Luxembourgish\"\n            },\n            {\n              \"id\": \"73\",\n              \"name\": \"Macedonian\"\n            },\n            {\n              \"id\": \"74\",\n              \"name\": \"Maithili\"\n            },\n            {\n              \"id\": \"75\",\n              \"name\": \"Malagasy\"\n            },\n            {\n              \"id\": \"76\",\n              \"name\": \"Malay\",\n              \"matchGroupKey\": \"Malay\"\n            },\n            {\n              \"id\": \"77\",\n              \"name\": \"Malayalam\"\n            },\n            {\n              \"id\": \"78\",\n              \"name\": \"Maltese\"\n            },\n            {\n              \"id\": \"79\",\n              \"name\": \"Mandarin Chinese\",\n              \"matchGroupKey\": \"Chinese\"\n            },\n            {\n              \"id\": \"80\",\n              \"name\": \"Manipuri\"\n            },\n            {\n              \"id\": \"81\",\n              \"name\": \"Maori\"\n            },\n            {\n              \"id\": \"82\",\n              \"name\": \"Marathi\"\n            },\n            {\n              \"id\": \"83\",\n              \"name\": \"Mizo\"\n            },\n            {\n              \"id\": \"84\",\n              \"name\": \"Mongolian\"\n            },\n            {\n              \"id\": \"85\",\n              \"name\": \"Nepali\"\n            },\n            {\n              \"id\": \"86\",\n              \"name\": \"Norwegian\",\n              \"matchGroupKey\": \"Norwegian\"\n            },\n            {\n              \"id\": \"87\",\n              \"name\": \"Odia\"\n            },\n            {\n              \"id\": \"88\",\n              \"name\": \"Oromo\"\n            },\n            {\n              \"id\": \"89\",\n              \"name\": \"Pashto\"\n            },\n            {\n              \"id\": \"90\",\n              \"name\": \"Persian\",\n              \"matchGroupKey\": \"Persian\"\n            },\n            {\n              \"id\": \"91\",\n              \"name\": \"Polish\",\n              \"matchGroupKey\": \"Polish\"\n            },\n            {\n              \"id\": \"92\",\n              \"name\": \"Portuguese\",\n              \"matchGroupKey\": \"Portuguese\"\n            },\n            {\n              \"id\": \"93\",\n              \"name\": \"Punjabi\",\n              \"matchGroupKey\": \"Punjabi\"\n            },\n            {\n              \"id\": \"94\",\n              \"name\": \"Quechua\"\n            },\n            {\n              \"id\": \"95\",\n              \"name\": \"Romanian\",\n              \"matchGroupKey\": \"Romanian\"\n            },\n            {\n              \"id\": \"96\",\n              \"name\": \"Russian\",\n              \"matchGroupKey\": \"Russian\"\n            },\n            {\n              \"id\": \"97\",\n              \"name\": \"Samoan\"\n            },\n            {\n              \"id\": \"98\",\n              \"name\": \"Sanskrit\"\n            },\n            {\n              \"id\": \"99\",\n              \"name\": \"Scots Gaelic\"\n            },\n            {\n              \"id\": \"100\",\n              \"name\": \"Sepedi\"\n            },\n            {\n              \"id\": \"101\",\n              \"name\": \"Serbian\"\n            },\n            {\n              \"id\": \"102\",\n              \"name\": \"Sesotho\"\n            },\n            {\n              \"id\": \"103\",\n              \"name\": \"Shona\"\n            },\n            {\n              \"id\": \"104\",\n              \"name\": \"Sindhi\"\n            },\n            {\n              \"id\": \"105\",\n              \"name\": \"Sinhala\"\n            },\n            {\n              \"id\": \"106\",\n              \"name\": \"Slovak\",\n              \"matchGroupKey\": \"Slovak\"\n            },\n            {\n              \"id\": \"107\",\n              \"name\": \"Slovenian\",\n              \"matchGroupKey\": \"Slovenian\"\n            },\n            {\n              \"id\": \"108\",\n              \"name\": \"Somali\"\n            },\n            {\n              \"id\": \"109\",\n              \"name\": \"Spanish\",\n              \"matchGroupKey\": \"Spanish\"\n            },\n            {\n              \"id\": \"110\",\n              \"name\": \"Sundanese\"\n            },\n            {\n              \"id\": \"111\",\n              \"name\": \"Swahili\",\n              \"matchGroupKey\": \"Swahili\"\n            },\n            {\n              \"id\": \"112\",\n              \"name\": \"Swedish\",\n              \"matchGroupKey\": \"Swedish\"\n            },\n            {\n              \"id\": \"113\",\n              \"name\": \"Tajik\"\n            },\n            {\n              \"id\": \"114\",\n              \"name\": \"Tamil\",\n              \"matchGroupKey\": \"Tamil\"\n            },\n            {\n              \"id\": \"115\",\n              \"name\": \"Tatar\"\n            },\n            {\n              \"id\": \"116\",\n              \"name\": \"Telugu\"\n            },\n            {\n              \"id\": \"117\",\n              \"name\": \"Thai\",\n              \"matchGroupKey\": \"Thai\"\n            },\n            {\n              \"id\": \"118\",\n              \"name\": \"Tigrinya\"\n            },\n            {\n              \"id\": \"119\",\n              \"name\": \"Tsonga\"\n            },\n            {\n              \"id\": \"120\",\n              \"name\": \"Turkish\",\n              \"matchGroupKey\": \"Turkish\"\n            },\n            {\n              \"id\": \"121\",\n              \"name\": \"Turkmen\"\n            },\n            {\n              \"id\": \"122\",\n              \"name\": \"Twi\"\n            },\n            {\n              \"id\": \"123\",\n              \"name\": \"Ukrainian\",\n              \"matchGroupKey\": \"Ukranian\"\n            },\n            {\n              \"id\": \"124\",\n              \"name\": \"Urdu\",\n              \"matchGroupKey\": \"Urdu\"\n            },\n            {\n              \"id\": \"125\",\n              \"name\": \"Uyghur\"\n            },\n            {\n              \"id\": \"126\",\n              \"name\": \"Uzbek\"\n            },\n            {\n              \"id\": \"127\",\n              \"name\": \"Vietnamese\",\n              \"matchGroupKey\": \"Vietnamese\"\n            },\n            {\n              \"id\": \"128\",\n              \"name\": \"Welsh\"\n            },\n            {\n              \"id\": \"129\",\n              \"name\": \"Xhosa\"\n            },\n            {\n              \"id\": \"130\",\n              \"name\": \"Yiddish\"\n            },\n            {\n              \"id\": \"131\",\n              \"name\": \"Yoruba\"\n            },\n            {\n              \"id\": \"132\",\n              \"name\": \"Zulu\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/language@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/language@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/language@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/language@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"minSelections\": 1,\n          \"maxSelections\": 5,\n          \"backgroundText\": \"Add languages\",\n          \"searchBackgroundText\": \"Search languages\",\n          \"sectionId\": 4,\n          \"sectionName\": \"Languages I know\",\n          \"matchGroupKey\": \"languages\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": false\n        }\n      ]", new System.Text.Json.JsonDocumentOptions()));

            migrationBuilder.UpdateData(
                table: "AvailableDescriptors",
                keyColumn: "Id",
                keyValue: 5,
                column: "Descriptors",
                value: System.Text.Json.JsonDocument.Parse("[\n        {\n          \"id\": \"de_1\",\n          \"name\": \"Zodiac\",\n          \"prompt\": \"What’s your star sign?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Capricorn\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Aquarius\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Pisces\"\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"Aries\"\n            },\n            {\n              \"id\": \"5\",\n              \"name\": \"Taurus\"\n            },\n            {\n              \"id\": \"6\",\n              \"name\": \"Gemini\"\n            },\n            {\n              \"id\": \"7\",\n              \"name\": \"Cancer\"\n            },\n            {\n              \"id\": \"8\",\n              \"name\": \"Leo\"\n            },\n            {\n              \"id\": \"9\",\n              \"name\": \"Virgo\"\n            },\n            {\n              \"id\": \"10\",\n              \"name\": \"Libra\"\n            },\n            {\n              \"id\": \"11\",\n              \"name\": \"Scorpio\"\n            },\n            {\n              \"id\": \"12\",\n              \"name\": \"Sagittarius\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/astrological_sign@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/astrological_sign@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/astrological_sign@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/astrological_sign@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 5,\n          \"sectionName\": \"More about me\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_9\",\n          \"name\": \"Education\",\n          \"prompt\": \"What is your education level?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Bachelor degree\",\n              \"matchGroupKey\": \"Bachelors\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"At uni\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"High school\",\n              \"matchGroupKey\": \"Highschool\"\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"PhD\",\n              \"matchGroupKey\": \"PhD\"\n            },\n            {\n              \"id\": \"5\",\n              \"name\": \"On a graduate programme\"\n            },\n            {\n              \"id\": \"6\",\n              \"name\": \"Master degree\",\n              \"matchGroupKey\": \"Masters\"\n            },\n            {\n              \"id\": \"7\",\n              \"name\": \"Trade school\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/education@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/education@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/education@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/education@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 5,\n          \"sectionName\": \"More about me\",\n          \"matchGroupKey\": \"education\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_33\",\n          \"name\": \"Family plans\",\n          \"prompt\": \"Do you want children?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"I want children\",\n              \"matchGroupKey\": \"Yes\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"I don’t want children\",\n              \"matchGroupKey\": \"No\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"I have children and want more\"\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"I have children and don’t want more\"\n            },\n            {\n              \"id\": \"5\",\n              \"name\": \"Not sure yet\",\n              \"matchGroupKey\": \"Maybe\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/kids@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/kids@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/kids@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/kids@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 5,\n          \"sectionName\": \"More about me\",\n          \"matchGroupKey\": \"wants_children\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_34\",\n          \"name\": \"COVID vaccine\",\n          \"prompt\": \"Are you vaccinated?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Vaccinated\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Unvaccinated\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Prefer not to say\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/covid_comfort@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/covid_comfort@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/covid_comfort@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/covid_comfort@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 5,\n          \"sectionName\": \"More about me\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_13\",\n          \"name\": \"Personality type\",\n          \"prompt\": \"What’s your personality type?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"INTJ\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"INTP\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"ENTJ\"\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"ENTP\"\n            },\n            {\n              \"id\": \"5\",\n              \"name\": \"INFJ\"\n            },\n            {\n              \"id\": \"6\",\n              \"name\": \"INFP\"\n            },\n            {\n              \"id\": \"7\",\n              \"name\": \"ENFJ\"\n            },\n            {\n              \"id\": \"8\",\n              \"name\": \"ENFP\"\n            },\n            {\n              \"id\": \"9\",\n              \"name\": \"ISTJ\"\n            },\n            {\n              \"id\": \"10\",\n              \"name\": \"ISFJ\"\n            },\n            {\n              \"id\": \"11\",\n              \"name\": \"ESTJ\"\n            },\n            {\n              \"id\": \"12\",\n              \"name\": \"ESFJ\"\n            },\n            {\n              \"id\": \"13\",\n              \"name\": \"ISTP\"\n            },\n            {\n              \"id\": \"14\",\n              \"name\": \"ISFP\"\n            },\n            {\n              \"id\": \"15\",\n              \"name\": \"ESTP\"\n            },\n            {\n              \"id\": \"16\",\n              \"name\": \"ESFP\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/mbti@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/mbti@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/mbti@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/mbti@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 5,\n          \"sectionName\": \"More about me\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_2\",\n          \"name\": \"Communication style\",\n          \"prompt\": \"What’s your communication style?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Big time texter\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Phone caller\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Video chatter\"\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"Bad texter\"\n            },\n            {\n              \"id\": \"5\",\n              \"name\": \"Better in person\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/communication_style@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/communication_style@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/communication_style@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/communication_style@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 5,\n          \"sectionName\": \"More about me\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_35\",\n          \"name\": \"Love style\",\n          \"prompt\": \"How do you receive love?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Thoughtful gestures\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Presents\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Touch\"\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"Compliments\"\n            },\n            {\n              \"id\": \"5\",\n              \"name\": \"Time together\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/love_language@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/love_language@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/love_language@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/love_language@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 5,\n          \"sectionName\": \"More about me\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        }\n      ]", new System.Text.Json.JsonDocumentOptions()));

            migrationBuilder.UpdateData(
                table: "AvailableDescriptors",
                keyColumn: "Id",
                keyValue: 6,
                column: "Descriptors",
                value: System.Text.Json.JsonDocument.Parse("[\n        {\n          \"id\": \"de_3\",\n          \"name\": \"Pets\",\n          \"prompt\": \"Do you have any pets?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Dog\",\n              \"matchGroupKey\": \"Dogs\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Cat\",\n              \"matchGroupKey\": \"Cats\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Reptile\"\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"Amphibian\"\n            },\n            {\n              \"id\": \"8\",\n              \"name\": \"Bird\"\n            },\n            {\n              \"id\": \"5\",\n              \"name\": \"Fish\"\n            },\n            {\n              \"id\": \"9\",\n              \"name\": \"Don’t have, but love\"\n            },\n            {\n              \"id\": \"11\",\n              \"name\": \"Other\",\n              \"matchGroupKey\": \"Other\"\n            },\n            {\n              \"id\": \"12\",\n              \"name\": \"Turtle\"\n            },\n            {\n              \"id\": \"13\",\n              \"name\": \"Hamster\"\n            },\n            {\n              \"id\": \"14\",\n              \"name\": \"Rabbit\"\n            },\n            {\n              \"id\": \"6\",\n              \"name\": \"Pet-free\"\n            },\n            {\n              \"id\": \"7\",\n              \"name\": \"All the pets\"\n            },\n            {\n              \"id\": \"16\",\n              \"name\": \"Want a pet\"\n            },\n            {\n              \"id\": \"17\",\n              \"name\": \"Allergic to pets\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/pets@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/pets@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/pets@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/pets@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 6,\n          \"sectionName\": \"Lifestyle\",\n          \"matchGroupKey\": \"pets\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_22\",\n          \"name\": \"Drinking\",\n          \"prompt\": \"How often do you drink?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"8\",\n              \"name\": \"Not for me\",\n              \"matchGroupKey\": \"No\"\n            },\n            {\n              \"id\": \"9\",\n              \"name\": \"Newly teetotal\"\n            },\n            {\n              \"id\": \"10\",\n              \"name\": \"Sober curious\"\n            },\n            {\n              \"id\": \"11\",\n              \"name\": \"On special occasions\",\n              \"matchGroupKey\": \"Sometimes\"\n            },\n            {\n              \"id\": \"12\",\n              \"name\": \"Socially, at the weekend\",\n              \"matchGroupKey\": \"Socially\"\n            },\n            {\n              \"id\": \"13\",\n              \"name\": \"Most nights\",\n              \"matchGroupKey\": \"Yes\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/drink_of_choice@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/drink_of_choice@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/drink_of_choice@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/drink_of_choice@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 6,\n          \"sectionName\": \"Lifestyle\",\n          \"matchGroupKey\": \"drinking\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_11\",\n          \"name\": \"How often do you smoke?\",\n          \"prompt\": \"How often do you smoke?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Social smoker\",\n              \"matchGroupKey\": \"Socially\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Smoker when drinking\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Non-smoker\",\n              \"matchGroupKey\": \"No\"\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"Smoker\",\n              \"matchGroupKey\": \"Yes\"\n            },\n            {\n              \"id\": \"6\",\n              \"name\": \"Trying to quit\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/smoking@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/smoking@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/smoking@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/smoking@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 6,\n          \"sectionName\": \"Lifestyle\",\n          \"matchGroupKey\": \"drinking\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_10\",\n          \"name\": \"Workout\",\n          \"prompt\": \"Do you exercise?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"4\",\n              \"name\": \"Every day\"\n            },\n            {\n              \"id\": \"5\",\n              \"name\": \"Often\",\n              \"matchGroupKey\": \"Often\"\n            },\n            {\n              \"id\": \"6\",\n              \"name\": \"Sometimes\",\n              \"matchGroupKey\": \"Sometimes\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Never\",\n              \"matchGroupKey\": \"Never\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/workout@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/workout@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/workout@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/workout@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 6,\n          \"sectionName\": \"Lifestyle\",\n          \"matchGroupKey\": \"exercise\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_7\",\n          \"name\": \"Dietary preference\",\n          \"prompt\": \"What are your dietary preferences?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Vegan\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Vegetarian\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Pescatarian\"\n            },\n            {\n              \"id\": \"9\",\n              \"name\": \"Kosher\"\n            },\n            {\n              \"id\": \"10\",\n              \"name\": \"Halal\"\n            },\n            {\n              \"id\": \"7\",\n              \"name\": \"Carnivore\"\n            },\n            {\n              \"id\": \"8\",\n              \"name\": \"Omnivore\"\n            },\n            {\n              \"id\": \"12\",\n              \"name\": \"Other\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/appetite@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/appetite@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/appetite@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/appetite@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 6,\n          \"sectionName\": \"Lifestyle\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_4\",\n          \"name\": \"Social media\",\n          \"prompt\": \"How active are you on social media?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Influencer status\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Socially active\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"Off the grid\"\n            },\n            {\n              \"id\": \"4\",\n              \"name\": \"Passive scroller\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/social_media@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/social_media@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/social_media@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/social_media@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 6,\n          \"sectionName\": \"Lifestyle\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        },\n        {\n          \"id\": \"de_17\",\n          \"name\": \"Sleeping habits\",\n          \"prompt\": \"What are your sleeping habits?\",\n          \"type\": \"single_selection_set\",\n          \"choices\": [\n            {\n              \"id\": \"1\",\n              \"name\": \"Early bird\"\n            },\n            {\n              \"id\": \"2\",\n              \"name\": \"Night owl\"\n            },\n            {\n              \"id\": \"3\",\n              \"name\": \"It varies\"\n            }\n          ],\n          \"iconUrl\": \"https://static-assets.gotinder.com/icons/descriptors/sleeping_habits@3x.png\",\n          \"iconUrls\": [\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/sleeping_habits@1x.png\",\n              \"quality\": \"1x\",\n              \"width\": 22,\n              \"height\": 22\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/sleeping_habits@2x.png\",\n              \"quality\": \"2x\",\n              \"width\": 44,\n              \"height\": 44\n            },\n            {\n              \"url\": \"https://static-assets.gotinder.com/icons/descriptors/sleeping_habits@3x.png\",\n              \"quality\": \"3x\",\n              \"width\": 66,\n              \"height\": 66\n            }\n          ],\n          \"sectionId\": 6,\n          \"sectionName\": \"Lifestyle\",\n          \"shouldLocalizeChoices\": true,\n          \"discoveryPreferencesEnabled\": true\n        }\n      ]", new System.Text.Json.JsonDocumentOptions()));

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Description", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("4cdd2b8e-5005-491b-a513-e3a2d7ac37ce"), null, "Woman", null },
                    { new Guid("6adbf96a-6fd2-405b-95d1-d9edc442723f"), null, "Beyond binary", null },
                    { new Guid("8708c64a-4e8c-4a31-86c1-98d9d678c124"), null, "Man", null }
                });

            migrationBuilder.InsertData(
                table: "QuestionCategories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5400), "Connection-building", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5400) },
                    { new Guid("1c275fd6-53c1-4521-8d9a-501a1e57b872"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5400), "Edgy", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5400) },
                    { new Guid("2ddab326-f330-481b-a6d8-73a8aa1d715a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5390), "Flirty", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5390) },
                    { new Guid("2ff7af7f-4e4f-4508-aa00-1ff45de82467"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5390), "Funny", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5390) },
                    { new Guid("ae9dd40b-b6b3-4f7f-a299-951ecd31235a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5380), "Sexual", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5380) },
                    { new Guid("f9d7cd77-d00f-4f90-ae3c-031b58519c07"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5410), "Dilemma", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5410) }
                });

            migrationBuilder.InsertData(
                table: "RoomContent",
                columns: new[] { "Id", "CreatedAt", "Description", "Duration", "Order", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("212842a5-9e8b-48bc-a641-c1005bb8b3d7"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(6170), "Brace yourself for some off-the-wall questions and give your best answers within the time limit!", 300m, 3, "Random Question Roulette", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(6170) },
                    { new Guid("4d82fb65-d616-4953-a4e7-fe5c5b7b3d6b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(6190), "Pop your best question to the remaining contenders, and whoever nails it gets the match!", 60m, 5, "The Final Rose", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(6190) },
                    { new Guid("8e408eee-0ed7-4199-8612-c851d127563d"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(6150), "Give us the scoop on the person behind the screen!", 60m, 1, "Meet & Greet", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(6150) },
                    { new Guid("e519ab86-a2f2-49cc-b76f-670d853e8f74"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(6180), "Get ready to field questions from your adoring audience!", 300m, 4, "Spotlight Q&A", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(6180) },
                    { new Guid("f7b4c72c-d2fe-411d-9e78-331259f14d44"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(6170), "Share your passions and two quirky facts about yourself!", 120m, 2, "Hobby Showcase & Fun Fact Extravaganza", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(6170) }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Description", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("05cbebab-f5cb-4a09-9b6b-e69cc80b170b"), "A man whose gender aligns with the sex they were assigned at birth.", "Cis man", new Guid("8708c64a-4e8c-4a31-86c1-98d9d678c124") },
                    { new Guid("0d1ee1ae-5720-4b2c-8f19-39dbb3efb3d5"), "A person who is transgender and their gender is different from the sex assigned to them at birth.", "Trans person", new Guid("6adbf96a-6fd2-405b-95d1-d9edc442723f") },
                    { new Guid("189e251e-06d4-4c02-b532-7c0ead76cf25"), "A person who was assigned female at birth, but presents as masculine. This person may or may not see themselves as a man or a transgender man.", "Transmasculine", new Guid("6adbf96a-6fd2-405b-95d1-d9edc442723f") },
                    { new Guid("36fc7720-0a8f-4b08-8d2a-95beff04a29d"), "A man born with one or more variations in sex characteristics that don’t fit binary ideas of male or female bodies.", "Intersex man", new Guid("8708c64a-4e8c-4a31-86c1-98d9d678c124") },
                    { new Guid("4398cce0-3204-4a4a-baf6-a77c9e80f426"), "An umbrella term used across US Native American and Canadian First Nations communities to honour the sacred role that people who are not exclusively cisgender and/or heterosexual hold.", "Two-Spirit", new Guid("6adbf96a-6fd2-405b-95d1-d9edc442723f") },
                    { new Guid("470743f2-35b8-4f95-bd44-5ca0ada83a52"), "An umbrella term that refers to people born with one or more variations in sex characteristics that don’t fit binary ideas of male or female bodies.", "Intersex", new Guid("6adbf96a-6fd2-405b-95d1-d9edc442723f") },
                    { new Guid("5fc85dc1-9ae0-4402-b564-311bd288caad"), "A person who does not have a single fixed gender.", "Gender fluid", new Guid("6adbf96a-6fd2-405b-95d1-d9edc442723f") },
                    { new Guid("68924bae-c5de-4987-a3c1-67f226f2c33a"), "A person who experiences multiple genders either simultaneously or over time.", "Pangender", new Guid("6adbf96a-6fd2-405b-95d1-d9edc442723f") },
                    { new Guid("6f132bdd-51bf-4840-8b76-312e8bbc989d"), "A woman born with one or more variations in sex characteristics that don’t fit binary ideas of male or female bodies.", "Intersex woman", new Guid("4cdd2b8e-5005-491b-a513-e3a2d7ac37ce") },
                    { new Guid("873c6fb0-bdaf-4449-b026-5c4b9c4a0409"), "A person who has two or more genders (can be simultaneously or fluid between them).", "Bigender", new Guid("6adbf96a-6fd2-405b-95d1-d9edc442723f") },
                    { new Guid("8d4d6b90-bc2c-495d-ad78-bfd436b16fc5"), "A person whose gender is beyond the exclusive categories of man and woman.", "Non-binary", new Guid("6adbf96a-6fd2-405b-95d1-d9edc442723f") },
                    { new Guid("9708700b-34be-4b54-a904-ec95bcf5cead"), "A woman whose gender is different from her sex assigned at birth.", "Trans woman", new Guid("4cdd2b8e-5005-491b-a513-e3a2d7ac37ce") },
                    { new Guid("a6bc74aa-e235-4211-bb31-3ef16774d88f"), "A person who was assigned male at birth, but presents as feminine. This person may or may not see themselves as a woman or a transgender woman.", "Transfeminine", new Guid("4cdd2b8e-5005-491b-a513-e3a2d7ac37ce") },
                    { new Guid("b6d8a7a9-8ac5-421d-9a88-17b3b9df5243"), "A man whose gender is different from his sex assigned at birth.", "Trans man", new Guid("8708c64a-4e8c-4a31-86c1-98d9d678c124") },
                    { new Guid("c7d392f7-293e-4969-b9d8-ef416df9c517"), "A person who is questioning their current gender and/or exploring other genders and expressions.", "Gender questioning", new Guid("6adbf96a-6fd2-405b-95d1-d9edc442723f") },
                    { new Guid("d7c76ad0-d770-4b4f-865d-c809310b4f76"), "A person who was assigned female at birth, but presents as masculine. This person may or may not see themselves as a man or a transgender man.", "Transmasculine", new Guid("8708c64a-4e8c-4a31-86c1-98d9d678c124") },
                    { new Guid("e6bbebd9-b191-460f-9472-7c4f9e71b6ad"), "A person who does not identify or express their gender within the gender binary.", "Genderqueer", new Guid("6adbf96a-6fd2-405b-95d1-d9edc442723f") },
                    { new Guid("e8175bac-4ee7-4605-80bf-c4bc2906cad3"), "A person who was assigned male at birth, but presents as feminine. This person may or may not see themselves as a woman or a transgender woman.", "Transfeminine", new Guid("6adbf96a-6fd2-405b-95d1-d9edc442723f") },
                    { new Guid("f1ea2c16-40dd-49f5-a982-4ab11ab162be"), "A woman whose gender aligns with the sex they were assigned at birth.", "Cis woman", new Guid("4cdd2b8e-5005-491b-a513-e3a2d7ac37ce") },
                    { new Guid("f9909746-a4b6-4d76-a24a-9c293dd8ceaa"), "A person who does not have a gender.", "Agender", new Guid("6adbf96a-6fd2-405b-95d1-d9edc442723f") }
                });

            migrationBuilder.InsertData(
                table: "SystemQuestions",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("010ad1dd-e62e-42e0-8897-9079192a2eae"), new Guid("f9d7cd77-d00f-4f90-ae3c-031b58519c07"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(6020), "Peanut butter or Nutella?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(6020) },
                    { new Guid("068410e4-017b-4a7f-93e9-adaec48a8e97"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(6000), "What’s the most important thing your life is missing?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(6000) },
                    { new Guid("07b1fe5e-cb80-47b2-8243-14b7eb9052d5"), new Guid("ae9dd40b-b6b3-4f7f-a299-951ecd31235a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5550), "What does your ideal one-night stand look like?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5550) },
                    { new Guid("09ebc59b-afd8-4d26-8754-fde26891aa79"), new Guid("1c275fd6-53c1-4521-8d9a-501a1e57b872"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5800), "Would you rather be stung by a thousand bees or stomp a kitten?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5800) },
                    { new Guid("18f33003-f0ab-4fcf-8504-4388422a5960"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5990), "What’s something you swear by?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5990) },
                    { new Guid("22eb7d19-724a-41ff-80e3-2664a1637e6e"), new Guid("f9d7cd77-d00f-4f90-ae3c-031b58519c07"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(6040), "Bath or shower?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(6040) },
                    { new Guid("26af3051-c5e3-4be6-86dc-f3db62ff1596"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5980), "Where do you go if you want to escape?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5990) },
                    { new Guid("2caac5fd-2ae2-4b3c-98ff-83dc2fc4245a"), new Guid("f9d7cd77-d00f-4f90-ae3c-031b58519c07"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(6060), "Dine-in or delivery?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(6060) },
                    { new Guid("2e2ee7a5-d820-4cdb-80b1-e3fede9315e0"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5840), "If you could make one decision to change the world, what would you do?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5840) },
                    { new Guid("2eb1b4fb-3153-45ae-91b1-1e3292394a4a"), new Guid("2ff7af7f-4e4f-4508-aa00-1ff45de82467"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5600), "Do you think that men can be gynecologists? (Second question) What if he sniffs his finger?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5600) },
                    { new Guid("30897864-329a-4b31-9734-24431b09a1c9"), new Guid("1c275fd6-53c1-4521-8d9a-501a1e57b872"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5780), "Would you rather be surrounded by people who brag all the time or by people who constantly complain?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5780) },
                    { new Guid("35d96d33-3e06-45f3-8d7f-0c2ebee86367"), new Guid("ae9dd40b-b6b3-4f7f-a299-951ecd31235a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5520), "What do you fantasize about when you touch yourself?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5520) },
                    { new Guid("3708badb-fe39-4c32-a6ed-f53f985c29de"), new Guid("2ddab326-f330-481b-a6d8-73a8aa1d715a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5690), "What do you find the most attractive in a man?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5690) },
                    { new Guid("3af295e8-f104-49c9-9aa6-e86653b3edf3"), new Guid("f9d7cd77-d00f-4f90-ae3c-031b58519c07"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(6050), "Burger or pizza?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(6050) },
                    { new Guid("3d861057-2ebe-4bc7-80b4-a45818de8b7a"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5890), "What’s your favorite and least favorite household chore?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5890) },
                    { new Guid("40d6b357-8672-4cda-a787-89104d7242d4"), new Guid("2ff7af7f-4e4f-4508-aa00-1ff45de82467"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5620), "What’s the last time you did something scary?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5620) },
                    { new Guid("46b1d1f3-c52c-4830-8af4-cbbefbd908e3"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5910), "Would you continue working if you were rich and didn’t need to?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5910) },
                    { new Guid("5129f301-67eb-4409-a63f-1ee1d7818139"), new Guid("ae9dd40b-b6b3-4f7f-a299-951ecd31235a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5500), "Do you prefer to make out with the lights on or off?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5500) },
                    { new Guid("57ae497a-42cb-4ab2-954d-7e1d6530657b"), new Guid("f9d7cd77-d00f-4f90-ae3c-031b58519c07"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(6040), "Love or money?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(6040) },
                    { new Guid("5a25cf8f-c3d8-46dc-bdc1-7a678967d0db"), new Guid("2ddab326-f330-481b-a6d8-73a8aa1d715a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5680), "What’s the best romantic surprise you’ve ever had?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5690) },
                    { new Guid("5a9ea3c8-c13f-4a03-98e8-b3afc5c464f8"), new Guid("ae9dd40b-b6b3-4f7f-a299-951ecd31235a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5550), "If a cute couple asked you to do a threesome, would you say yes?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5550) },
                    { new Guid("5b1b1cfa-68aa-4dac-9158-83cc09614fbd"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5930), "What’s something that gives your life meaning?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5930) },
                    { new Guid("5d8baeed-c97c-4ee8-838a-92a1e9c35b57"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5830), "Would you rather travel to the past or the future?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5830) },
                    { new Guid("63bbe4c1-0663-4c81-8a1d-560d908beed7"), new Guid("ae9dd40b-b6b3-4f7f-a299-951ecd31235a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5530), "Have you ever had sex with someone you just met?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5530) },
                    { new Guid("64236237-303b-413f-a85e-6995567bdb87"), new Guid("2ff7af7f-4e4f-4508-aa00-1ff45de82467"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5640), "You’re on a first date with a dude you like and you let out an audible fart. What do you do?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5640) },
                    { new Guid("67fb3e02-5f57-446a-80ec-6ef68fc1f46c"), new Guid("2ddab326-f330-481b-a6d8-73a8aa1d715a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5710), "What do you think is the most important thing a woman can give to a man?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5710) },
                    { new Guid("6a70650d-2aee-4856-89cd-9e3b85138eaa"), new Guid("2ff7af7f-4e4f-4508-aa00-1ff45de82467"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5650), "You find out your best friend is a lesbian and she’s in love with you. How do you react?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5650) },
                    { new Guid("6abb0974-9ef4-4b81-9fe0-91ea86214709"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5870), "What’s the most romantic thing you’ve ever done for someone?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5870) },
                    { new Guid("6b25e225-2219-4ea1-9d29-0d181e5c3800"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5970), "What do you wish you cared less about?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5970) },
                    { new Guid("70ba2d93-3e2e-4bd0-b8e2-bcf519958a17"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5870), "Is there a way you could fall head over heels for a man? What would that look like?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5870) },
                    { new Guid("749ba5de-0cf0-407f-8330-0cbcd99a6a9f"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5930), "What dating advice would you give your younger self?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5930) },
                    { new Guid("767ab92d-8117-477a-bfd1-576efc3380d8"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5980), "What do your friends and family call you?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5980) },
                    { new Guid("7a12bd37-ef52-4d67-952f-a3dad415fd36"), new Guid("ae9dd40b-b6b3-4f7f-a299-951ecd31235a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5570), "Where do you like to be touched most?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5570) },
                    { new Guid("7b0f9739-407d-4a60-8c02-5e81767d94d6"), new Guid("ae9dd40b-b6b3-4f7f-a299-951ecd31235a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5470), "Do you prefer firm or light touches?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5470) },
                    { new Guid("7b16abbd-1d06-46c2-9638-709c34817d01"), new Guid("f9d7cd77-d00f-4f90-ae3c-031b58519c07"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(6020), "Flight or invisibility?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(6020) },
                    { new Guid("81590d97-0fcf-4a92-92b1-29a2e202c458"), new Guid("2ddab326-f330-481b-a6d8-73a8aa1d715a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5740), "Do you prefer cuddling or kissing?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5740) },
                    { new Guid("8375d127-afb9-4205-ae3e-f1bf05b2b488"), new Guid("ae9dd40b-b6b3-4f7f-a299-951ecd31235a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5490), "Do you think it’s okay if a guy wants to be submissive in the bedroom?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5490) },
                    { new Guid("853a5bd1-7152-4fc8-a858-302134325962"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(6010), "How long ago did you tell someone you loved them?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(6010) },
                    { new Guid("855036c3-db5b-43bb-bb44-a293ba965fba"), new Guid("ae9dd40b-b6b3-4f7f-a299-951ecd31235a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5570), "What’s the dirtiest thing someone said to you during sex?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5570) },
                    { new Guid("8702c46f-dd37-4ce5-821d-e1d400a6d916"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(6000), "What do you wish more people knew about you?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(6000) },
                    { new Guid("89fd183b-2f5c-4f30-916e-b981b0e0ca8b"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5950), "If you could only put on one piece of makeup, what would it be?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5950) },
                    { new Guid("92ed913a-d93e-47cc-be7b-b2186aa44af5"), new Guid("1c275fd6-53c1-4521-8d9a-501a1e57b872"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5810), "Your dad and boyfriend switch bodies (Freaky Friday style). The only way to switch them back is to have sex with them, lights on and sober. Who do you pick?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5810) },
                    { new Guid("938bca5a-7cc1-4fd0-9710-29ece719558c"), new Guid("2ddab326-f330-481b-a6d8-73a8aa1d715a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5670), "What’s your favorite way to be seduced by a man?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5670) },
                    { new Guid("94244795-9802-43d7-83a6-88e4fe5f745b"), new Guid("2ddab326-f330-481b-a6d8-73a8aa1d715a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5670), "What do you miss most about being single? (She has to pick something.)", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5680) },
                    { new Guid("94c34a14-37cb-43b8-a20b-44ae8dc782f1"), new Guid("1c275fd6-53c1-4521-8d9a-501a1e57b872"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5770), "Would you rather fight young Mike Tyson once or talk like Mike Tyson for the rest of your life?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5770) },
                    { new Guid("94f04d37-a585-4c54-a131-1639f942d077"), new Guid("ae9dd40b-b6b3-4f7f-a299-951ecd31235a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5490), "Would you rather receive or give oral?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5490) },
                    { new Guid("98458966-8deb-4acd-97df-abeaed0f3232"), new Guid("2ff7af7f-4e4f-4508-aa00-1ff45de82467"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5640), "You and all your friends have to enter a mixed martial arts tournament. Do you win?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5640) },
                    { new Guid("9a121386-672a-41bb-a5cd-969c57ae19da"), new Guid("2ddab326-f330-481b-a6d8-73a8aa1d715a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5740), "What do you wear when you go to sleep?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5740) },
                    { new Guid("a37b78d3-e34f-45f4-8b7f-36b1dcc8c131"), new Guid("1c275fd6-53c1-4521-8d9a-501a1e57b872"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5760), "Would you rather have a boyfriend who’s stinking rich and ugly? Or a friend who’s dirt poor and handsome?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5760) },
                    { new Guid("a4139abd-418a-4c37-8b9e-df10bfe6efe7"), new Guid("1c275fd6-53c1-4521-8d9a-501a1e57b872"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5790), "Would you rather Win $50,000 or let your best friend win $500,000?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5790) },
                    { new Guid("a54a501d-1f45-43bd-9dcb-e981f282c0e5"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5960), "What’s the one compliment you get the most?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5960) },
                    { new Guid("a604f987-ca3f-4a46-948e-ad79e071594c"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5920), "If you could change one thing about the way you were raised, what would that be?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5920) },
                    { new Guid("ab174561-0f43-493a-ab79-8be1fc7465e8"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5820), "What’s a recent book you read or movie you saw that taught you something?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5820) },
                    { new Guid("af90c16e-8f0e-4bc9-90aa-5883588db8d4"), new Guid("2ff7af7f-4e4f-4508-aa00-1ff45de82467"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5660), "You’re at a party and really need to drop a deuce. But their toilet doesn’t flush. Do you use the toilet anyway, or do your business in the yard?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5660) },
                    { new Guid("b04a27a6-c780-4490-aaa4-3d3a5c48b902"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5840), "If you could travel the universe on the condition that you were never allowed to set foot on earth again, would you go?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5840) },
                    { new Guid("b19c4fca-b7e1-4d34-ba65-2660b694d186"), new Guid("2ff7af7f-4e4f-4508-aa00-1ff45de82467"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5620), "You have to assassinate someone who really deserves it. How do you do it?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5620) },
                    { new Guid("b1f0014a-eed1-4de4-8454-c5844d5ed2f8"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5910), "What does your ideal night look like? Do you go out or are you at home with friends?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5910) },
                    { new Guid("b23d40d8-e7ec-4382-b766-9b831076ae06"), new Guid("ae9dd40b-b6b3-4f7f-a299-951ecd31235a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5460), "What physical act gives you the most pleasure?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5460) },
                    { new Guid("b3e42a73-a830-4aac-b805-6911627ffa95"), new Guid("2ddab326-f330-481b-a6d8-73a8aa1d715a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5700), "What does good sex mean to you?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5700) },
                    { new Guid("ba46b3bb-15a9-4f53-9b6c-7825b34da75e"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5850), "If you could ask your pet 3 questions, what would they be?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5860) },
                    { new Guid("bc44673f-2efb-49aa-b55c-18cb14f3d641"), new Guid("2ff7af7f-4e4f-4508-aa00-1ff45de82467"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5600), "What was the last time you went skinny dipping?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5610) },
                    { new Guid("be7aa718-99f0-4ffb-8f82-bab82383135b"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5950), "What would you like to get for your birthday?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5950) },
                    { new Guid("c5afe04f-c319-4bb3-8be9-f51735a0890f"), new Guid("2ddab326-f330-481b-a6d8-73a8aa1d715a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5720), "What’s the hottest thing a guy can do for you?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5730) },
                    { new Guid("c616a239-c55a-42fa-b0ed-964be5fbcb21"), new Guid("1c275fd6-53c1-4521-8d9a-501a1e57b872"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5800), "Would you rather be with the person you love forever, but also wear a shirt made out of their pubes, or be alone for the rest of your life but wear whatever you want?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5800) },
                    { new Guid("c9f7cd6d-5e07-4e4a-b0c3-6cb09b8124b7"), new Guid("ae9dd40b-b6b3-4f7f-a299-951ecd31235a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5560), "What are your thoughts on toys?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5560) },
                    { new Guid("ca473ed6-4652-45fc-be92-226b4cb60bcf"), new Guid("2ff7af7f-4e4f-4508-aa00-1ff45de82467"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5580), "What meal or snack will you never refuse?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5580) },
                    { new Guid("cdda0fe1-8261-493d-bb63-1c40b47ecba5"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5850), "What’s the first thing you do when you get back home from work?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5850) },
                    { new Guid("cfd1e62b-1b8b-4737-b440-4adaf0490169"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5860), "What’s something you’d like to be remembered for?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5860) },
                    { new Guid("d04bb78d-f8a0-4577-98a3-bc700472d266"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5900), "What’s something you’ve always wanted to do, but haven’t?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5900) },
                    { new Guid("d1ab3bbc-538f-4462-9903-ea3df011e31c"), new Guid("1c275fd6-53c1-4521-8d9a-501a1e57b872"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5760), "Would you rather have hiccups for the rest of your life or constantly feel like you have to sneeze?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5760) },
                    { new Guid("d22893a8-cf57-41b5-91d2-29c6e06ac895"), new Guid("2ff7af7f-4e4f-4508-aa00-1ff45de82467"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5630), "If your friends and family hear that you were arrested, what would they think you did?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5630) },
                    { new Guid("d6f20102-e99c-456a-ae4e-215200700cb1"), new Guid("2ddab326-f330-481b-a6d8-73a8aa1d715a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5720), "What makes you feel sexy?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5720) },
                    { new Guid("d76225a8-f791-4780-82f6-08d68d9448d3"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5940), "What song would you want to play on your wedding day?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5940) },
                    { new Guid("d7a5f829-e2d2-4393-8f1d-d36d817f2bd7"), new Guid("ae9dd40b-b6b3-4f7f-a299-951ecd31235a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5510), "Are you more dominant or submissive in bed?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5510) },
                    { new Guid("dc4b6457-a516-498d-a73a-b971a8a6b1b5"), new Guid("2ddab326-f330-481b-a6d8-73a8aa1d715a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5700), "What are your biggest turn-offs?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5700) },
                    { new Guid("dd3afa44-c7c4-4553-bf9f-8d596b26254b"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5820), "Name three things that you can do to get out of a funk.", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5820) },
                    { new Guid("df289085-afeb-470f-bc73-eeb1d15ab362"), new Guid("2ddab326-f330-481b-a6d8-73a8aa1d715a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5730), "Can you surrender to love or is it something that scares you?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5730) },
                    { new Guid("dfa7f43d-065b-4c6f-b7f2-798e42295261"), new Guid("ae9dd40b-b6b3-4f7f-a299-951ecd31235a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5540), "What’s the dirtiest thought you’ve ever had about a stranger?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5540) },
                    { new Guid("e1dff12d-6255-46fb-a0e8-3580dc1c70a8"), new Guid("1c275fd6-53c1-4521-8d9a-501a1e57b872"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5750), "Would you rather have a cat with a human face or a dog with human hands?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5750) },
                    { new Guid("e332b4ea-55cb-4535-84a4-9ee656dddcf5"), new Guid("f9d7cd77-d00f-4f90-ae3c-031b58519c07"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(6030), "Quit coffee or never have snacks during films and series?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(6030) },
                    { new Guid("e363f864-f107-461a-b7d4-ea44ee2fb4b8"), new Guid("2ff7af7f-4e4f-4508-aa00-1ff45de82467"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5660), "Do you prefer the smell of freshly cut grass or freshly baked bread?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5660) },
                    { new Guid("ebacb433-19e0-4dae-8e86-ff4e8010f423"), new Guid("ae9dd40b-b6b3-4f7f-a299-951ecd31235a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5480), "Do guy-on-guy videos turn you on more than guy-on-girl?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5480) },
                    { new Guid("f13bd981-833d-4e7e-b860-89acb2286909"), new Guid("1c275fd6-53c1-4521-8d9a-501a1e57b872"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5780), "Would you rather speak every language fluently or play every instrument perfectly?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5780) },
                    { new Guid("f2a1cd16-a41b-4722-a2ef-06134aa05d95"), new Guid("ae9dd40b-b6b3-4f7f-a299-951ecd31235a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5530), "Do you like to roleplay?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5530) },
                    { new Guid("f5413d7d-3897-4117-9c83-836878b090ec"), new Guid("2ff7af7f-4e4f-4508-aa00-1ff45de82467"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5590), "What’s the weirdest thing you carry in your purse?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5590) },
                    { new Guid("f6ff4720-261f-46ba-9915-dd5f3021eac5"), new Guid("2ff7af7f-4e4f-4508-aa00-1ff45de82467"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5590), "Zombies are overrunning the world. How do you defend yourself?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5590) },
                    { new Guid("f73f2b1b-7909-400d-9052-837cc101c2f9"), new Guid("ae9dd40b-b6b3-4f7f-a299-951ecd31235a"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5510), "Would you rather end a good first date with a passionate kiss or sex?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5510) },
                    { new Guid("f9237174-afa2-463f-8045-716a896025ca"), new Guid("2ff7af7f-4e4f-4508-aa00-1ff45de82467"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5610), "Would you date someone who’s cute but mega dumb?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5610) },
                    { new Guid("f9b037c0-29fb-434d-a658-03f552a11ca5"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5880), "If you were the mayor of your city, what rule would you instantly enforce?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5880) },
                    { new Guid("fc94d573-4127-4972-9061-a1018de510e2"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5890), "What’s one responsibility of yours that you’d prefer to delegate to a professional?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5890) },
                    { new Guid("fd46e021-6190-4938-819c-b3cbad7880be"), new Guid("02ecd7c1-d98c-4b87-9577-a3ba9268913b"), new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5960), "Where do you feel the most at home?", new DateTime(2024, 11, 17, 22, 34, 32, 471, DateTimeKind.Utc).AddTicks(5970) }
                });
        }
    }
}