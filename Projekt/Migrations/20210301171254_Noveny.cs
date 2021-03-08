using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt.Migrations
{
    public partial class Noveny : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Betegseg",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tipus = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Betegseg", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Elofordulas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Honap = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elofordulas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Gyujtott",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Resz = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gyujtott", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Felhasznalas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Gyujtott_id = table.Column<int>(type: "INTEGER", nullable: false),
                    Betegseg_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Elo_Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Felhasznalas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Felhasznalas_Betegseg_Betegseg_ID",
                        column: x => x.Betegseg_ID,
                        principalTable: "Betegseg",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Felhasznalas_Elofordulas_Elo_Id",
                        column: x => x.Elo_Id,
                        principalTable: "Elofordulas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Felhasznalas_Gyujtott_Gyujtott_id",
                        column: x => x.Gyujtott_id,
                        principalTable: "Gyujtott",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Novenyek",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Latin = table.Column<string>(type: "TEXT", nullable: true),
                    Magyar = table.Column<string>(type: "TEXT", nullable: true),
                    Kep = table.Column<string>(type: "TEXT", nullable: true),
                    Informacio = table.Column<string>(type: "TEXT", nullable: true),
                    Felh_Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Novenyek", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Novenyek_Felhasznalas_Felh_Id",
                        column: x => x.Felh_Id,
                        principalTable: "Felhasznalas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Betegseg",
                columns: new[] { "ID", "Tipus" },
                values: new object[] { 1, "Anyagcsere" });

            migrationBuilder.InsertData(
                table: "Betegseg",
                columns: new[] { "ID", "Tipus" },
                values: new object[] { 11, "Vizeletkiválasztó" });

            migrationBuilder.InsertData(
                table: "Betegseg",
                columns: new[] { "ID", "Tipus" },
                values: new object[] { 10, "Nemiszervek" });

            migrationBuilder.InsertData(
                table: "Betegseg",
                columns: new[] { "ID", "Tipus" },
                values: new object[] { 8, "Légzőszervek" });

            migrationBuilder.InsertData(
                table: "Betegseg",
                columns: new[] { "ID", "Tipus" },
                values: new object[] { 7, "Keringési rendszer" });

            migrationBuilder.InsertData(
                table: "Betegseg",
                columns: new[] { "ID", "Tipus" },
                values: new object[] { 9, "Mozgásszervek" });

            migrationBuilder.InsertData(
                table: "Betegseg",
                columns: new[] { "ID", "Tipus" },
                values: new object[] { 5, "Idegrendszer" });

            migrationBuilder.InsertData(
                table: "Betegseg",
                columns: new[] { "ID", "Tipus" },
                values: new object[] { 4, "Emésztőrendszer" });

            migrationBuilder.InsertData(
                table: "Betegseg",
                columns: new[] { "ID", "Tipus" },
                values: new object[] { 3, "Bőr" });

            migrationBuilder.InsertData(
                table: "Betegseg",
                columns: new[] { "ID", "Tipus" },
                values: new object[] { 2, "Általános" });

            migrationBuilder.InsertData(
                table: "Betegseg",
                columns: new[] { "ID", "Tipus" },
                values: new object[] { 6, "Immunrendszer" });

            migrationBuilder.InsertData(
                table: "Elofordulas",
                columns: new[] { "ID", "Honap" },
                values: new object[] { 8, "augusztus" });

            migrationBuilder.InsertData(
                table: "Elofordulas",
                columns: new[] { "ID", "Honap" },
                values: new object[] { 12, "december" });

            migrationBuilder.InsertData(
                table: "Elofordulas",
                columns: new[] { "ID", "Honap" },
                values: new object[] { 11, "november" });

            migrationBuilder.InsertData(
                table: "Elofordulas",
                columns: new[] { "ID", "Honap" },
                values: new object[] { 10, "október" });

            migrationBuilder.InsertData(
                table: "Elofordulas",
                columns: new[] { "ID", "Honap" },
                values: new object[] { 9, "szeptember" });

            migrationBuilder.InsertData(
                table: "Elofordulas",
                columns: new[] { "ID", "Honap" },
                values: new object[] { 7, "július" });

            migrationBuilder.InsertData(
                table: "Elofordulas",
                columns: new[] { "ID", "Honap" },
                values: new object[] { 4, "április" });

            migrationBuilder.InsertData(
                table: "Elofordulas",
                columns: new[] { "ID", "Honap" },
                values: new object[] { 5, "május" });

            migrationBuilder.InsertData(
                table: "Elofordulas",
                columns: new[] { "ID", "Honap" },
                values: new object[] { 3, "március" });

            migrationBuilder.InsertData(
                table: "Elofordulas",
                columns: new[] { "ID", "Honap" },
                values: new object[] { 2, "február" });

            migrationBuilder.InsertData(
                table: "Elofordulas",
                columns: new[] { "ID", "Honap" },
                values: new object[] { 1, "január" });

            migrationBuilder.InsertData(
                table: "Elofordulas",
                columns: new[] { "ID", "Honap" },
                values: new object[] { 6, "június" });

            migrationBuilder.InsertData(
                table: "Gyujtott",
                columns: new[] { "ID", "Resz" },
                values: new object[] { 5, "Szár" });

            migrationBuilder.InsertData(
                table: "Gyujtott",
                columns: new[] { "ID", "Resz" },
                values: new object[] { 1, "Bogyó" });

            migrationBuilder.InsertData(
                table: "Gyujtott",
                columns: new[] { "ID", "Resz" },
                values: new object[] { 2, "Virág" });

            migrationBuilder.InsertData(
                table: "Gyujtott",
                columns: new[] { "ID", "Resz" },
                values: new object[] { 3, "Levél" });

            migrationBuilder.InsertData(
                table: "Gyujtott",
                columns: new[] { "ID", "Resz" },
                values: new object[] { 4, "Gyökér" });

            migrationBuilder.InsertData(
                table: "Gyujtott",
                columns: new[] { "ID", "Resz" },
                values: new object[] { 6, "Termés" });

            migrationBuilder.InsertData(
                table: "Felhasznalas",
                columns: new[] { "ID", "Betegseg_ID", "Elo_Id", "Gyujtott_id" },
                values: new object[] { 2, 2, 8, 2 });

            migrationBuilder.InsertData(
                table: "Felhasznalas",
                columns: new[] { "ID", "Betegseg_ID", "Elo_Id", "Gyujtott_id" },
                values: new object[] { 3, 3, 9, 2 });

            migrationBuilder.InsertData(
                table: "Felhasznalas",
                columns: new[] { "ID", "Betegseg_ID", "Elo_Id", "Gyujtott_id" },
                values: new object[] { 1, 1, 8, 3 });

            migrationBuilder.InsertData(
                table: "Felhasznalas",
                columns: new[] { "ID", "Betegseg_ID", "Elo_Id", "Gyujtott_id" },
                values: new object[] { 4, 4, 7, 3 });

            migrationBuilder.InsertData(
                table: "Felhasznalas",
                columns: new[] { "ID", "Betegseg_ID", "Elo_Id", "Gyujtott_id" },
                values: new object[] { 5, 5, 3, 3 });

            migrationBuilder.InsertData(
                table: "Felhasznalas",
                columns: new[] { "ID", "Betegseg_ID", "Elo_Id", "Gyujtott_id" },
                values: new object[] { 10, 10, 4, 3 });

            migrationBuilder.InsertData(
                table: "Felhasznalas",
                columns: new[] { "ID", "Betegseg_ID", "Elo_Id", "Gyujtott_id" },
                values: new object[] { 11, 11, 9, 3 });

            migrationBuilder.InsertData(
                table: "Felhasznalas",
                columns: new[] { "ID", "Betegseg_ID", "Elo_Id", "Gyujtott_id" },
                values: new object[] { 6, 6, 1, 4 });

            migrationBuilder.InsertData(
                table: "Felhasznalas",
                columns: new[] { "ID", "Betegseg_ID", "Elo_Id", "Gyujtott_id" },
                values: new object[] { 7, 7, 9, 4 });

            migrationBuilder.InsertData(
                table: "Felhasznalas",
                columns: new[] { "ID", "Betegseg_ID", "Elo_Id", "Gyujtott_id" },
                values: new object[] { 8, 8, 3, 5 });

            migrationBuilder.InsertData(
                table: "Felhasznalas",
                columns: new[] { "ID", "Betegseg_ID", "Elo_Id", "Gyujtott_id" },
                values: new object[] { 9, 9, 7, 5 });

            migrationBuilder.InsertData(
                table: "Novenyek",
                columns: new[] { "ID", "Felh_Id", "Informacio", "Kep", "Latin", "Magyar" },
                values: new object[] { 2, 2, "A virágból készült tea vízhajtó, emésztést elősegítő, köhögéscsillapító hatású. Megfázásra, hörghurutra, izzasztószerként és immunrendszeri serkentőként használják. A friss bodzahajtás erős hashajtó. Használják még vértisztításra, fülfájásra, rekedtségre. A bogyó izzasztó, nagy mennyiségben hashajtó, ödéma és reuma ellen ajánljuk. Friss leve vagy a belőle készült lekvár bizonyítottan kitűnő szer a TBC gyógyítására. A bodzafa kérge purgáló, féreghajtó hatású. Erős vízhajtó, heveny vesegyulladásra, általános ödémásodásra ajánlják.", "bodza.jpg", "Sambucus", "Bodza" });

            migrationBuilder.InsertData(
                table: "Novenyek",
                columns: new[] { "ID", "Felh_Id", "Informacio", "Kep", "Latin", "Magyar" },
                values: new object[] { 3, 3, "Az erdei borostyán (Hedera helix) kúszó növekedésű, örökzöld növény, mely Európa nagy részén, valamint Délnyugat-Ázsiában is őshonos.Kiválóan alkalmas kerítések, épületek, fák, befuttatására, valamint talajtakaró növényként is megállja a helyét, mivel támaszték híján a talajt fedi be.Levélzetét karéjos levelek alkotják, melyek a fajtától függően egyszínű zöldek, valamint többszínű, mintásak is lehetnek. Ernyős virágzata kicsi, zöldessárga virágokból áll, melyek késő nyáron és kora ősszel nyílnak.Virágai nektárban gazdagok, méheket és más rovarokat vonzanak a kertbe. ", "borostyan.jpg", "Hedera helix", "Borostyán" });

            migrationBuilder.InsertData(
                table: "Novenyek",
                columns: new[] { "ID", "Felh_Id", "Informacio", "Kep", "Latin", "Magyar" },
                values: new object[] { 1, 1, "Tekintettel a fekete áfonyában található számos antioxidáns hatóanyagra, nem meglepő, hogy a kutatások során kimutatták, hogy a szervezet számára fokozott antioxidáns védelmet biztosít az oxidatív stresszel szemben, többek közt a szív- és érrendszer tekintetében.De ami meglepő a fekete áfonyával kapcsolatos kutatások eredményei közt,hogy hatását az egész testre kifejti.Nemcsak a keringési rendszer az,melyről kimutatták, hogy a fekete áfonya fogyasztásával erősödik az antioxidáns védelme.", "afonya.jpg", "Vaccinium myrtillus", "Fekete áfonya" });

            migrationBuilder.InsertData(
                table: "Novenyek",
                columns: new[] { "ID", "Felh_Id", "Informacio", "Kep", "Latin", "Magyar" },
                values: new object[] { 4, 4, "Máriatövist már régóta használják a természetes gyógyításban és akik használják, azt állítják, hogy sokkal egészségesebbek. Tavasszal és ősszel frissen is hozzájuthatunk, a növény kivonatával erősíthetjük a májunkat és megvédhetjük legfontosabb méregtelenítő szervünket a sejtekbe jutó toxinok káros hatásaitól, mivel azokat eltávolítja és feldolgozza. A máriatövisnek antidepresszáns hatása is van, segít mozgósítani a máj stagnáló energiáit. A máriatövis megnyugtatja és nedvesíti a nyálkahártyákat, így gyógyír lehet a vese, a húgyhólyag és a bőrgyulladások számára.", "maria.jpg", "Silybum marianum", "Máriatövis" });

            migrationBuilder.InsertData(
                table: "Novenyek",
                columns: new[] { "ID", "Felh_Id", "Informacio", "Kep", "Latin", "Magyar" },
                values: new object[] { 5, 5, "A páfrányok ideális szobanövények, melyek már évtizedek óta kedvenceink. A páfrányok csoportjából a szobapáfrány (Nephrolepis) a legismertebb. Sokoldalú növények, melyek egyben gondoskodnak az egészséges klímáról is otthonában azzal, hogy tisztítják a levegőt és megfelelő páratartalmat teremtenek. Mivel a páfrányok, mint szobanövények eredetileg a (szub)trópusi területekről származnak, a magas páratartalmat kedvelik. Ebből kifolyólag ideálisak lehetnek fürdőszobai növénynek.", "pafrany.jpg", "Ginkgo biloba", "Páfrányfenyő" });

            migrationBuilder.InsertData(
                table: "Novenyek",
                columns: new[] { "ID", "Felh_Id", "Informacio", "Kep", "Latin", "Magyar" },
                values: new object[] { 10, 10, "Csak hazánkban nyolc különböző palástfűfajt ismerünk, amelyek küllemükben és gyógyhatásukban is nagyon hasonlóak, a név tehát gyűjtőfogalom. A rózsafélék (Rosaceae) családjába tartozó, évelő növény. Gyöktörzse fejlett, ezzel vészeli át a telet.Szára a termőhelytől függően a földön heverőtől az 50 cm magasig változhat.", "palastfu.jpg", "Alchemilla monticola", "Palástfű" });

            migrationBuilder.InsertData(
                table: "Novenyek",
                columns: new[] { "ID", "Felh_Id", "Informacio", "Kep", "Latin", "Magyar" },
                values: new object[] { 11, 11, "A medveszőlő egy rendkívül különleges megjelenésű örökzöld növény, melynek élénkpiros termése leginkább a vörös áfonyára hasonlít. A növény levelét és leveles hajtásait lehet hasznosítani gyógyászati célokra, például tea vagy borogatás készítésére.Számos jótékony hatással rendelkezik. Eredményesen kezelhetőek vele a húgyúti megbetegedések, a nőgyógyászati problémák, a magas vérnyomás és a hasmenés, de elősegítheti a sebgyógyulást is. ", "medveszolo.jpg", "Uvae ursi folium", "Medveszőlő levél" });

            migrationBuilder.InsertData(
                table: "Novenyek",
                columns: new[] { "ID", "Felh_Id", "Informacio", "Kep", "Latin", "Magyar" },
                values: new object[] { 6, 6, "A ginzenget Ázsiában és Észak-Amerikában már évszázadok óta használják a gyógyászatban. A legtöbben az agyműködés serkentésére, a koncentráció növelésére, a szellemi és fizikai állóképesség javítására alkalmazzák. A ginseng (ginzeng) segítségével a depresszió, a szorongás és a krónikus fáradtság is természetes módon kezelhető.", "ginzeng.jpg", "Panax", "Ginzeng" });

            migrationBuilder.InsertData(
                table: "Novenyek",
                columns: new[] { "ID", "Felh_Id", "Informacio", "Kep", "Latin", "Magyar" },
                values: new object[] { 7, 7, "A fokhagyma antibakteriális és antimikotikus (gombaellenes) hatása révén légúti megbetegedések és a Candida albicans okozta fertőzések kezelésében használatos. Továbbá tágítja az ereket is. Rendszeres, kúraszerű alkalmazása csökkenti a vér káros LDL-koleszterin-szintjét, antioxidánsként serkenti az immunrendszert, csökkenti a mellkasi fertőzéseket, véralvadásgátló- és vérnyomáscsökkentő.", "fokhagyma.jpg", "Alii sativi bulbus", "Fokhagyma" });

            migrationBuilder.InsertData(
                table: "Novenyek",
                columns: new[] { "ID", "Felh_Id", "Informacio", "Kep", "Latin", "Magyar" },
                values: new object[] { 8, 8, "Elsősorban veseműködés javítására szolgál, vízhajtó hatása kísérletileg igazolt. Vesekövet, vesehomokot lehet vele elhajtani, mindenféle húgyúti fertőzést megszüntetni.Szilícium és szerves ásvány tartalma miatt kiváló tonizáló, erősítő hatású. A romák salátaként fogyasztják zsenge termőhajtásait ebből a célból. Csontok, köröm erősítésére is használjuk. Csontritkulás esetén porrá őrölve kell fogyasztani. Jó vérzéscsillapító orrvérzés, tüdővérzés, bőséges havivérzés esetén.", "zsurlo.jpg", "Equisetum arvense", "Mezei zsurló" });

            migrationBuilder.InsertData(
                table: "Novenyek",
                columns: new[] { "ID", "Felh_Id", "Informacio", "Kep", "Latin", "Magyar" },
                values: new object[] { 9, 9, "Diétázás nélkül is csökkenti a testsúlyt, normalizálja a vérnyomást, mérsékli az ízületi gyulladást, lassítja a sclerosis multiplex előrehaladását, enyhíti a másnaposságot.Segíti a bőr megújulási folyamatát. Enyhíti a menstruációs panaszokat. Szerepet játszik a vér koleszterinszintjének csökkentésében. A kozmetikaipar a száraz, gyulladt bőr ápolására alkalmazható szereket készít belőle.", "ligetszepe.jpg", "Oenothera biennis", "Ligetszépe" });

            migrationBuilder.CreateIndex(
                name: "IX_Felhasznalas_Betegseg_ID",
                table: "Felhasznalas",
                column: "Betegseg_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Felhasznalas_Elo_Id",
                table: "Felhasznalas",
                column: "Elo_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Felhasznalas_Gyujtott_id",
                table: "Felhasznalas",
                column: "Gyujtott_id");

            migrationBuilder.CreateIndex(
                name: "IX_Novenyek_Felh_Id",
                table: "Novenyek",
                column: "Felh_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Novenyek");

            migrationBuilder.DropTable(
                name: "Felhasznalas");

            migrationBuilder.DropTable(
                name: "Betegseg");

            migrationBuilder.DropTable(
                name: "Elofordulas");

            migrationBuilder.DropTable(
                name: "Gyujtott");
        }
    }
}
