using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrandLineAuto.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Id for brand"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of brand"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Image for logo")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of category"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of category"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Image of the category")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductManufacturers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of manufacturer"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the manufacturer")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductManufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrandModelsSeries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of Series"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of Series"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Image of Series"),
                    productionYears = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false, comment: "Year of the Series"),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier to belonged brand")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandModelsSeries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrandModelsSeries_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of subCategory"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the subCategory"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Image of the subCategory"),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of the category")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BrandModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Id for brand model"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name for given model"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Image of the model"),
                    yearProduced = table.Column<int>(type: "int", nullable: false, comment: "Year the car is produced"),
                    typeCoupe = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false, comment: "Type of coupe"),
                    fuelType = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false, comment: "Fuel type"),
                    Engine = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Engine"),
                    BrandModelsSeriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Belongs to a serie")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrandModels_BrandModelsSeries_BrandModelsSeriesId",
                        column: x => x.BrandModelsSeriesId,
                        principalTable: "BrandModelsSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of product"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Name of product"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Image of the product"),
                    Description = table.Column<string>(type: "nvarchar(650)", maxLength: 650, nullable: false, comment: "Information about the product"),
                    SpecificInfo1 = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Information about the product"),
                    SpecificInfo2 = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Information about the product"),
                    SpecificInfo3 = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Information about the product"),
                    SpecificInfo4 = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Information about the product"),
                    SpecificInfo5 = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Information about the product"),
                    SpecificInfo6 = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Information about the product"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Price of the product"),
                    SubCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "It has sub categories"),
                    ProductManufacturerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Each product have manufacturer")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductManufacturers_ProductManufacturerId",
                        column: x => x.ProductManufacturerId,
                        principalTable: "ProductManufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BrandModelProductJoinTables",
                columns: table => new
                {
                    BrandModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Mapping to brand model"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Mapping to product")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandModelProductJoinTables", x => new { x.BrandModelId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_BrandModelProductJoinTables_BrandModels_BrandModelId",
                        column: x => x.BrandModelId,
                        principalTable: "BrandModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BrandModelProductJoinTables_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("0a7cb569-2e0e-4c76-a28e-92e3d355fa28"), "https://images.seeklogo.com/logo-png/16/1/porsche-logo-png_seeklogo-168544.png", "Porsche" },
                    { new Guid("3f6c9c77-4c1b-4d2b-9df2-1e8e4c27bba4"), "https://blog.logomaster.ai/hs-fs/hubfs/bmw-logo-1963.jpg?width=672&height=454&name=bmw-logo-1963.jpg", "BMW" },
                    { new Guid("9b2f1c3d-2f50-4c4c-b4ce-0f7d7f2c9f61"), "https://static.vecteezy.com/system/resources/previews/020/499/027/non_2x/mercedes-benz-brand-logo-symbol-white-with-name-design-german-car-automobile-illustration-with-black-background-free-vector.jpg", "Mercedes-Benz" },
                    { new Guid("c4c8a1c9-7c29-4d47-8c19-3e9d2ef0be55"), "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ae/Logo_audi.jpg/960px-Logo_audi.jpg", "Audi" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("5a3d9c41-7f2b-4e8c-9c31-0fb28d74a922"), "https://www.autopower.bg/images/categories/%D0%A1%D0%BF%D0%B8%D1%80%D0%B0%D1%87%D0%BD%D0%B0%20%D1%81%D0%B8%D1%81%D1%82%D0%B5%D0%BC%D0%B0.jpg", "Braking System" },
                    { new Guid("d4f0a8c7-12b9-4c53-8d77-61f4b3e2c915"), "https://www.autopower.bg/images/categories/%D0%A7%D0%B0%D1%81%D1%82%D0%B8%20%D0%B7%D0%B0%20%D0%B4%D0%B2%D0%B8%D0%B3%D0%B0%D1%82%D0%B5%D0%BB.jpg", "Engine Parts" }
                });

            migrationBuilder.InsertData(
                table: "ProductManufacturers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2c9f4b17-63e1-4e8a-8f5c-91d2a7b6c014"), "Brembo" },
                    { new Guid("94a0c6e3-2b71-4d8f-9f3e-0c8d27ab14d2"), "Febi bilstein" },
                    { new Guid("b18e57d4-0fa2-41e3-9c42-7d3f1a8ce5b9"), "Metzger autotelie" }
                });

            migrationBuilder.InsertData(
                table: "BrandModelsSeries",
                columns: new[] { "Id", "BrandId", "ImageUrl", "Name", "productionYears" },
                values: new object[,]
                {
                    { new Guid("3b4f2a17-665d-43ee-bac8-0e3f4d92bb10"), new Guid("0a7cb569-2e0e-4c76-a28e-92e3d355fa28"), "https://media.drive.com.au/obj/tx_q:50,rs:auto:1920:1080:1/driveau/upload/cms/uploads/vdfiilc13rajkg86q3ps", "Porsche Panamera", "2009-2015" },
                    { new Guid("4a0dbf77-2e3a-4c1f-a1c9-3e2df59482b3"), new Guid("9b2f1c3d-2f50-4c4c-b4ce-0f7d7f2c9f61"), "https://automoto.bg/listings/media/listing//1708102204_1708033948_1.jpg", "Mercedes-Benz C classe", "2006-2012" },
                    { new Guid("67f3c8d2-1af4-4e5d-9d10-8a3e72c6c4aa"), new Guid("c4c8a1c9-7c29-4d47-8c19-3e9d2ef0be55"), "https://images.ctfassets.net/uaddx06iwzdz/2KRO0CKDLDQnp38hfmbkpq/b63ce3731355495d119623ac742df6fc/audi-a6-l-01.jpg", "Audi A6 Serie", "2011-2017" },
                    { new Guid("a8c1f4eb-6b5a-4c9e-94df-1b3c7f8e2190"), new Guid("9b2f1c3d-2f50-4c4c-b4ce-0f7d7f2c9f61"), "https://mobistatic3.focus.bg/mobile/photosorg/536/1/big//11755160806701536_rv.webp", "Mercedes-Benz E classe", "2005-2010" },
                    { new Guid("c2f7d914-5b8a-4e3d-92b4-1af08c7e33a1"), new Guid("3f6c9c77-4c1b-4d2b-9df2-1e8e4c27bba4"), "https://cdn3.focus.bg/autodata/i/bmw/m5/m5-e60/large/20a25cb2b439604fe5db3c205f7e11b5.jpg", "BMW E60-2", "2004-2010" },
                    { new Guid("d91ce0f5-7af1-4b78-a28e-f56e4c1c92bb"), new Guid("c4c8a1c9-7c29-4d47-8c19-3e9d2ef0be55"), "https://media.ed.edmunds-media.com/audi/a8/2008/oem/2008_audi_a8_sedan_l-quattro_fq_oem_2_1600.jpg", "Audi A8 Serie", "2006-2010" },
                    { new Guid("e2f3b6c1-9c4d-4c88-86b8-7f92b1e4a6d2"), new Guid("3f6c9c77-4c1b-4d2b-9df2-1e8e4c27bba4"), "https://cdn3.focus.bg/autodata/i/bmw/3er/3er-e90/large/ef6298b9bf11a376c37eebb71bd96c77.jpg", "BMW E90-3", "2004-2012" },
                    { new Guid("f88c3d66-2c44-4c84-9a55-64b1c385f7ae"), new Guid("0a7cb569-2e0e-4c76-a28e-92e3d355fa28"), "https://porschepictures.flowcenter.de/pmdb/thumbnail.cgi?id=252983&w=1935&h=1089&crop=1&public=1&cs=0e7eaa33c7c2d827", "Porsche 911", "2004-2012" }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("0be4c29f-3f11-4a88-bd42-89e1cf72d4a3"), new Guid("5a3d9c41-7f2b-4e8c-9c31-0fb28d74a922"), "https://www.autopower.bg/images/categories/75x75/%D0%A1%D0%BF%D0%B8%D1%80%D0%B0%D1%87%D0%BD%D0%B8%20%D0%B4%D0%B8%D1%81%D0%BA%D0%BE%D0%B2%D0%B5.jpg", "Brake discs" },
                    { new Guid("6cd1f0b8-92b5-45a4-a6c1-3f84d9c2b7e0"), new Guid("d4f0a8c7-12b9-4c53-8d77-61f4b3e2c915"), "https://www.autopower.bg/images/categories/75x75/%D0%90%D0%BD%D0%B3%D1%80%D0%B5%D0%BD%D0%B0%D0%B6%D0%BD%D0%B0%20%D0%B2%D0%B5%D1%80%D0%B8%D0%B3%D0%B0.png", "Timing Chain" },
                    { new Guid("a3f79de2-58c4-49e8-9b6b-e24fdc81f927"), new Guid("5a3d9c41-7f2b-4e8c-9c31-0fb28d74a922"), "https://www.autopower.bg/images/categories/75x75/%D0%9D%D0%B0%D0%BA%D0%BB%D0%B0%D0%B4%D0%BA%D0%B8.jpg", "Overlays" },
                    { new Guid("f29b31c4-0e52-4c7d-8b1f-9e4da37c1aa6"), new Guid("d4f0a8c7-12b9-4c53-8d77-61f4b3e2c915"), "https://www.autopower.bg/images/categories/75x75/EGR%20%D0%BA%D0%BB%D0%B0%D0%BF%D0%B0%D0%BD.png", "EGR valve" }
                });

            migrationBuilder.InsertData(
                table: "BrandModels",
                columns: new[] { "Id", "BrandModelsSeriesId", "Engine", "ImageUrl", "Name", "fuelType", "typeCoupe", "yearProduced" },
                values: new object[,]
                {
                    { new Guid("0d9e3f11-b78c-47fa-b1c5-a4c2f59d8e17"), new Guid("3b4f2a17-665d-43ee-bac8-0e3f4d92bb10"), "4.8L V8", "https://smartcdn.gprod.postmedia.digital/driving/wp-content/uploads/2013/10/7607683.jpg", "Porsche Panamera GTS", "Petrol", "Sedan", 2012 },
                    { new Guid("0fa2e9d1-4e8b-4c76-bf33-9a2d6c107be9"), new Guid("4a0dbf77-2e3a-4c1f-a1c9-3e2df59482b3"), "C63 AMG", "https://car-images.bauersecure.com/wp-images/12978/1mercedesc63amgdrive.jpg", "Mercedes-Benz C63", "Petrol", "Sedan", 2010 },
                    { new Guid("31c4e0aa-9f12-4b0d-8f7e-55a1cb2d7c44"), new Guid("e2f3b6c1-9c4d-4c88-86b8-7f92b1e4a6d2"), "335i", "https://www.automoli.com/common/vehicles/_assets/img/gallery/f98/bmw-3-series-convertible-e93-lci-facelift-2010.jpg", "E93", "Petrol", "Cabrio", 2009 },
                    { new Guid("3bd17af4-9c81-4bcd-a0c0-251f7c8d9476"), new Guid("67f3c8d2-1af4-4e5d-9d10-8a3e72c6c4aa"), "3.0 TDI", "https://7cars.bg/wp-content/uploads/2025/02/1-copy-1.jpg", "Audi A6 3.0", "Diesel", "Sedan", 2013 },
                    { new Guid("4e8c1f22-9d4b-4f36-a7c1-2b9f53d1e8aa"), new Guid("e2f3b6c1-9c4d-4c88-86b8-7f92b1e4a6d2"), "320i", "https://img-ik.cars.co.za/images/2022/12Dec/E90BMW3SeriesSedanBuyersGuide/tr:n-news_large/2007-m3-sedan-2.jpg?tr=w-800", "E90", "Petrol", "Sedan", 2007 },
                    { new Guid("6a7fc1d9-325e-4a99-8b13-cdb42f75e610"), new Guid("d91ce0f5-7af1-4b78-a28e-f56e4c1c92bb"), "3.0 TDI", "https://www.automobile-catalog.com/img/pictonorzw/audi/audi_a8070013_117.jpg", "Audi A8", "Diesel", "Sedan", 2007 },
                    { new Guid("7de41fa8-1c26-4f3e-9d72-04c9fd8a33b7"), new Guid("a8c1f4eb-6b5a-4c9e-94df-1b3c7f8e2190"), "320 CDI", "https://media.carsandbids.com/cdn-cgi/image/width=2080,quality=70/da4b9237bacccdf19c0760cab7aec4a8359010b0/photos/xlWuI-DUMXN2-2.0r28NUnna.jpg?t=161221805027", "Mercedes-Benz E320", "Diesel", "Sedan", 2008 },
                    { new Guid("82f7a4c9-53d9-4ef0-8c11-7b3fd95a2c10"), new Guid("a8c1f4eb-6b5a-4c9e-94df-1b3c7f8e2190"), "550 AMG", "https://www.magnatuning.com/images/Mercedes-E-Class-W211-Exclusive-Body-Kit_picture_48790.jpg", "Mercedes-Benz E550", "Petrol", "Sedan", 2009 },
                    { new Guid("9cbf2146-7c33-4a51-9f2c-41e7a4d92bb8"), new Guid("4a0dbf77-2e3a-4c1f-a1c9-3e2df59482b3"), "320 CDI", "https://i0.wp.com/bestsellingcarsblog.com/wp-content/uploads/2011/06/Mercedes-C-Class-Germany-2008.jpg?resize=600%2C344&ssl=1", "Mercedes-Benz C320", "Diesel", "Sedan", 2007 },
                    { new Guid("b2c4f8a3-ef52-4b98-9da2-38c1f4c7e212"), new Guid("67f3c8d2-1af4-4e5d-9d10-8a3e72c6c4aa"), "3.0 TDI", "https://hips.hearstapps.com/hmg-prod/amv-prod-cad-assets/images/11q3/409394/2012-audi-a6-avant-tdi-diesel-review-car-and-driver-photo-411689-s-original.jpg?fill=1:1&resize=1200:*", "Audi A6 3.0", "Diesel", "Wagon", 2015 },
                    { new Guid("c8f3d27a-14a0-4c8b-94b7-1fa9c4d5e3c2"), new Guid("d91ce0f5-7af1-4b78-a28e-f56e4c1c92bb"), "4.2 FSI V8", "https://www.netcarshow.com/Audi-A8_L-2008-Rear_Three-Quarter.970bbea1.jpg", "Audi A8L", "Petrol", "Sedan", 2008 },
                    { new Guid("e41b0c92-0fd2-49e3-a9cb-708e5d34b126"), new Guid("f88c3d66-2c44-4c84-9a55-64b1c385f7ae"), "3.8L", "https://media.carsandbids.com/cdn-cgi/image/width=2080,quality=70/7a0a3c6148108c9c64425dd85e0181fa3cccb652/photos/vqhXN-hxQ.XHngqM4HaJ.jpg?t=161354154263", "Porsche 911 Carrera S", "Petrol", "Coupe", 2006 },
                    { new Guid("f1a7c0d4-35b2-4c88-8c9d-0a7e1f54b6d3"), new Guid("c2f7d914-5b8a-4e3d-92b4-1af08c7e33a1"), "5.0 V10 Naturally aspirated", "https://www.secretentourage.com/wp-content/uploads/2014/12/cover.jpg", "E60 M5", "Petrol", "Sedan", 2010 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "ProductManufacturerId", "SpecificInfo1", "SpecificInfo2", "SpecificInfo3", "SpecificInfo4", "SpecificInfo5", "SpecificInfo6", "SubCategoryId" },
                values: new object[,]
                {
                    { new Guid("7e24b1c9-3a5f-44d0-9e72-0c1fb78d4aa3"), "The specific drilling of Brembo Xtra brake discs provides a brilliant and efficient performance in any braking condition, to emphasise the driving style of true enthusiasts.", "https://www.autopower.bg/images/%D1%81%D0%BF%D0%B8%D1%80%D0%B0%D1%87%D0%B5%D0%BD-%D0%B4%D0%B8%D1%81%D0%BA-BREMBO-XTRA-LINE-Xtra-0997931X-BMW-3-Sedan-E90-320-i-imagetabig-845520901699346-BREMBO.jpg", "Brembo XTRA Line - Xtra", 240.5m, new Guid("2c9f4b17-63e1-4e8a-8f5c-91d2a7b6c014"), "Brake disc thickness [mm]:   20mm", "height [mm]: 66mm", "centering diameter [mm]: 75mm", "outer diameter [mm]: 300mm", "processing:  high-carbon", "", new Guid("0be4c29f-3f11-4a88-bd42-89e1cf72d4a3") },
                    { new Guid("f4a9d0c2-8b11-4e35-b6f2-9c7a1d54e820"), "Brembo Xtra: the perfect brake pad for Brembo Xtra and Brembo Max brake discs.", "https://www.autopower.bg/images/%D0%BD%D0%B0%D0%BA%D0%BB%D0%B0%D0%B4%D0%BA%D0%B8-BREMBO-XTRA-LINE-P06036X-BMW-3-Cabrio-E93-330-i-imagetabig-845520901733463-BREMBO.jpg", "Brembo XTRA LINE P 06 036X", 225.45m, new Guid("2c9f4b17-63e1-4e8a-8f5c-91d2a7b6c014"), "Installation side: Front axle", "width [mm]: 155mm", "thickness [mm]: 20mm", "height [mm]: 64mm", "", "", new Guid("a3f79de2-58c4-49e8-9b6b-e24fdc81f927") }
                });

            migrationBuilder.InsertData(
                table: "BrandModelProductJoinTables",
                columns: new[] { "BrandModelId", "ProductId" },
                values: new object[,]
                {
                    { new Guid("31c4e0aa-9f12-4b0d-8f7e-55a1cb2d7c44"), new Guid("7e24b1c9-3a5f-44d0-9e72-0c1fb78d4aa3") },
                    { new Guid("4e8c1f22-9d4b-4f36-a7c1-2b9f53d1e8aa"), new Guid("f4a9d0c2-8b11-4e35-b6f2-9c7a1d54e820") },
                    { new Guid("7de41fa8-1c26-4f3e-9d72-04c9fd8a33b7"), new Guid("7e24b1c9-3a5f-44d0-9e72-0c1fb78d4aa3") },
                    { new Guid("9cbf2146-7c33-4a51-9f2c-41e7a4d92bb8"), new Guid("f4a9d0c2-8b11-4e35-b6f2-9c7a1d54e820") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrandModelProductJoinTables_ProductId",
                table: "BrandModelProductJoinTables",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandModels_BrandModelsSeriesId",
                table: "BrandModels",
                column: "BrandModelsSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandModelsSeries_BrandId",
                table: "BrandModelsSeries",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductManufacturerId",
                table: "Products",
                column: "ProductManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategoryId",
                table: "Products",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrandModelProductJoinTables");

            migrationBuilder.DropTable(
                name: "BrandModels");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "BrandModelsSeries");

            migrationBuilder.DropTable(
                name: "ProductManufacturers");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
