using Microsoft.EntityFrameworkCore;

namespace Projekt.Models
{
    //Adatbázis adatok: ha eltűnne az adatbázis, migráció segítségével
    //a fontos adatokat visszahozhatjuk. Ezt nem hazsnálja a program, csak a 
    //migráció során
    public static class NovenySeed
    {
        public static void Betegseg(this ModelBuilder builder)
        {


            builder.Entity<Betegseg>().HasData(
                new Betegseg { ID = 1, Tipus = "Anyagcsere" },
                new Betegseg { ID = 2, Tipus = "Általános" },
                new Betegseg { ID = 3, Tipus = "Bőr" },
                new Betegseg { ID = 4, Tipus = "Emésztőrendszer" },
                new Betegseg { ID = 5, Tipus = "Idegrendszer" },
                new Betegseg { ID = 6, Tipus = "Immunrendszer" },
                new Betegseg { ID = 7, Tipus = "Keringési rendszer" },
                new Betegseg { ID = 8, Tipus = "Légzőszervek" },
                new Betegseg { ID = 9, Tipus = "Mozgásszervek" },
                new Betegseg { ID = 10, Tipus = "Nemiszervek" },
                new Betegseg { ID = 11, Tipus = "Vizeletkiválasztó" }
                );
        }
        public static void Gyujtott(this ModelBuilder builder)
        {


            builder.Entity<Gyujtott>().HasData(
                new Gyujtott { ID = 1, Resz = "Bogyó" },
                new Gyujtott { ID = 2, Resz = "Virág" },
                new Gyujtott { ID = 3, Resz = "Levél" },
                new Gyujtott { ID = 4, Resz = "Gyökér" },
                new Gyujtott { ID = 5, Resz = "Szár" },
                new Gyujtott { ID = 6, Resz = "Termés" }

                );
        }
        public static void Felhasznalas(this ModelBuilder builder)
        {


            builder.Entity<Felhasznalas>().HasData(
                new Felhasznalas { ID = 1, Elo_Id = 8, Gyujtott_id = 3, Betegseg_ID = 1 },
                new Felhasznalas { ID = 2, Elo_Id = 8, Gyujtott_id = 2, Betegseg_ID = 2 },
                new Felhasznalas { ID = 3, Elo_Id = 9, Gyujtott_id = 2, Betegseg_ID = 3 },
                new Felhasznalas { ID = 4, Elo_Id = 7, Gyujtott_id = 3, Betegseg_ID = 4 },
                new Felhasznalas { ID = 5, Elo_Id = 3, Gyujtott_id = 3, Betegseg_ID = 5 },
                new Felhasznalas { ID = 6, Elo_Id = 1, Gyujtott_id = 4, Betegseg_ID = 6 },
                new Felhasznalas { ID = 7, Elo_Id = 9, Gyujtott_id = 4, Betegseg_ID = 7 },
                new Felhasznalas { ID = 8, Elo_Id = 3, Gyujtott_id = 5, Betegseg_ID = 8 },
                new Felhasznalas { ID = 9, Elo_Id = 7, Gyujtott_id = 5, Betegseg_ID = 9 },
                new Felhasznalas { ID = 10, Elo_Id = 4, Gyujtott_id = 3, Betegseg_ID = 10 },
                new Felhasznalas { ID = 11, Elo_Id = 9, Gyujtott_id = 3, Betegseg_ID = 11 }
                );
        }

        public static void Elofordulas(this ModelBuilder builder)
        {


            builder.Entity<Elofordulas>().HasData(
                new Elofordulas { Honap = "január", ID = 1 },
                new Elofordulas { Honap = "február", ID = 2 },
                new Elofordulas { Honap = "március", ID = 3 },
                new Elofordulas { Honap = "április", ID = 4 },
                new Elofordulas { Honap = "május", ID = 5 },
                new Elofordulas { Honap = "június", ID = 6 },
                new Elofordulas { Honap = "július", ID = 7 },
                new Elofordulas { Honap = "augusztus", ID = 8 },
                new Elofordulas { Honap = "szeptember", ID = 9 },
                new Elofordulas { Honap = "október", ID = 10 },
                new Elofordulas { Honap = "november", ID = 11 },
                new Elofordulas { Honap = "december", ID = 12 }
                );
        }
        public static void Novenyek(this ModelBuilder builder)
        {


            builder.Entity<Novenyek>().HasData(
                new Novenyek
                {
                    ID = 1,
                    Latin = "Vaccinium myrtillus",
                    Magyar = "Fekete áfonya",
                    Felh_Id = 1,
                    Kep = "afonya.jpg",
                    Informacio = "Tekintettel a fekete áfonyában található számos antioxidáns hatóanyagra, nem meglepő, hogy a kutatások során kimutatták, " +
                    "hogy a szervezet számára fokozott antioxidáns védelmet biztosít az oxidatív stresszel szemben, többek közt a szív- és érrendszer tekintetében." +
                    "De ami meglepő a fekete áfonyával kapcsolatos kutatások eredményei közt," +
                    "hogy hatását az egész testre kifejti.Nemcsak a keringési rendszer az," +
                    "melyről kimutatták, hogy a fekete áfonya fogyasztásával erősödik az antioxidáns védelme."
                },

                new Novenyek
                {
                    ID = 2,
                    Latin = "Sambucus",
                    Magyar = "Bodza",
                    Felh_Id = 2,
                    Kep = "bodza.jpg",
                    Informacio = "A virágból készült tea vízhajtó, emésztést elősegítő, köhögéscsillapító hatású. Megfázásra, hörghurutra, izzasztószerként és immunrendszeri serkentőként használják. " +
                    "A friss bodzahajtás erős hashajtó. Használják még vértisztításra, fülfájásra, rekedtségre. A bogyó izzasztó, nagy mennyiségben hashajtó, ödéma és reuma ellen ajánljuk. " +
                    "Friss leve vagy a belőle készült lekvár bizonyítottan kitűnő szer a TBC gyógyítására. A bodzafa kérge purgáló, féreghajtó hatású. Erős vízhajtó, heveny vesegyulladásra, általános ödémásodásra ajánlják."

                },
                new Novenyek
                {
                    ID = 3,
                    Latin = "Hedera helix",
                    Magyar = "Borostyán",
                    Felh_Id = 3,
                    Kep = "borostyan.jpg",
                    Informacio = "Az erdei borostyán (Hedera helix) kúszó növekedésű, örökzöld növény, mely Európa nagy részén, valamint Délnyugat-Ázsiában is őshonos." +
                    "Kiválóan alkalmas kerítések, épületek, fák, befuttatására, valamint talajtakaró növényként is megállja a helyét, mivel támaszték híján a talajt fedi be." +
                    "Levélzetét karéjos levelek alkotják, melyek a fajtától függően egyszínű zöldek, valamint többszínű, mintásak is lehetnek. Ernyős virágzata kicsi, zöldessárga" +
                    " virágokból áll, melyek késő nyáron és kora ősszel nyílnak." +
                    "Virágai nektárban gazdagok, méheket és más rovarokat vonzanak a kertbe. "
                },
                new Novenyek
                {
                    ID = 4,
                    Latin = "Silybum marianum",
                    Magyar = "Máriatövis",
                    Felh_Id = 4,
                    Kep = "maria.jpg",
                    Informacio = "Máriatövist már régóta használják a természetes gyógyításban és akik használják, azt állítják, hogy sokkal egészségesebbek. " +
                    "Tavasszal és ősszel frissen is hozzájuthatunk, a növény kivonatával erősíthetjük a májunkat és megvédhetjük legfontosabb méregtelenítő szervünket a " +
                    "sejtekbe jutó toxinok káros hatásaitól, mivel azokat eltávolítja és feldolgozza. A máriatövisnek antidepresszáns hatása is van, segít mozgósítani a máj stagnáló" +
                    " energiáit. A máriatövis megnyugtatja és nedvesíti a nyálkahártyákat, így gyógyír lehet a vese, a húgyhólyag és a bőrgyulladások számára."
                },
                new Novenyek
                {
                    ID = 5,
                    Latin = "Ginkgo biloba",
                    Magyar = "Páfrányfenyő",
                    Felh_Id = 5,
                    Kep = "pafrany.jpg",
                    Informacio = "A páfrányok ideális szobanövények, melyek már évtizedek óta kedvenceink. A páfrányok csoportjából a szobapáfrány (Nephrolepis) a legismertebb. " +
                    "Sokoldalú növények, melyek egyben gondoskodnak az egészséges klímáról is otthonában azzal, hogy tisztítják a levegőt és megfelelő páratartalmat teremtenek. " +
                    "Mivel a páfrányok, mint szobanövények eredetileg a (szub)trópusi területekről származnak, a magas páratartalmat kedvelik. " +
                    "Ebből kifolyólag ideálisak lehetnek fürdőszobai növénynek."
                },
                new Novenyek
                {
                    ID = 6,
                    Latin = "Panax",
                    Magyar = "Ginzeng",
                    Felh_Id = 6,
                    Kep = "ginzeng.jpg",
                    Informacio = "A ginzenget Ázsiában és Észak-Amerikában már évszázadok óta használják a gyógyászatban. " +
                    "A legtöbben az agyműködés serkentésére, a koncentráció növelésére, a szellemi és fizikai állóképesség javítására alkalmazzák. " +
                    "A ginseng (ginzeng) segítségével a depresszió, a szorongás és a krónikus fáradtság is természetes módon kezelhető."
                },
                new Novenyek
                {
                    ID = 7,
                    Latin = "Alii sativi bulbus",
                    Magyar = "Fokhagyma",
                    Felh_Id = 7,
                    Kep = "fokhagyma.jpg",
                    Informacio = "A fokhagyma antibakteriális és antimikotikus (gombaellenes) hatása révén légúti megbetegedések és a Candida albicans okozta fertőzések kezelésében használatos" +
                    ". Továbbá tágítja az ereket is. Rendszeres, kúraszerű alkalmazása csökkenti a vér káros LDL-koleszterin-szintjét, antioxidánsként serkenti az immunrendszert," +
                    " csökkenti a mellkasi fertőzéseket, véralvadásgátló- és vérnyomáscsökkentő."
                },
                new Novenyek
                {
                    ID = 8,
                    Latin = "Equisetum arvense",
                    Magyar = "Mezei zsurló",
                    Felh_Id = 8,
                    Kep = "zsurlo.jpg",
                    Informacio = "Elsősorban veseműködés javítására szolgál, vízhajtó hatása kísérletileg igazolt." +
                    " Vesekövet, vesehomokot lehet vele elhajtani, mindenféle húgyúti fertőzést megszüntetni.Szilícium és szerves ásvány tartalma miatt kiváló tonizáló, erősítő hatású. " +
                    "A romák salátaként fogyasztják zsenge termőhajtásait ebből a célból. Csontok, köröm erősítésére is használjuk. " +
                    "Csontritkulás esetén porrá őrölve kell fogyasztani. Jó vérzéscsillapító orrvérzés, tüdővérzés, bőséges havivérzés esetén."
                },
                new Novenyek
                {
                    ID = 9,
                    Latin = "Oenothera biennis",
                    Magyar = "Ligetszépe",
                    Felh_Id = 9,
                    Kep = "ligetszepe.jpg",
                    Informacio = "Diétázás nélkül is csökkenti a testsúlyt, normalizálja a vérnyomást, mérsékli az ízületi gyulladást, lassítja a sclerosis multiplex előrehaladását, " +
                    "enyhíti a másnaposságot.Segíti a bőr megújulási folyamatát. Enyhíti a menstruációs panaszokat. Szerepet játszik a vér koleszterinszintjének csökkentésében. " +
                    "A kozmetikaipar a száraz, gyulladt bőr ápolására alkalmazható szereket készít belőle."
                },
                new Novenyek
                {
                    ID = 10,
                    Latin = "Alchemilla monticola",
                    Magyar = "Palástfű",
                    Felh_Id = 10,
                    Kep = "palastfu.jpg",
                    Informacio = "Csak hazánkban nyolc különböző palástfűfajt ismerünk, amelyek küllemükben és gyógyhatásukban is nagyon hasonlóak," +
                    " a név tehát gyűjtőfogalom. A rózsafélék (Rosaceae) családjába tartozó, évelő növény. " +
                    "Gyöktörzse fejlett, ezzel vészeli át a telet.Szára a termőhelytől függően a földön heverőtől az 50 cm magasig változhat."
                },
                new Novenyek
                {
                    ID = 11,
                    Latin = "Uvae ursi folium",
                    Magyar = "Medveszőlő levél",
                    Felh_Id = 11,
                    Kep = "medveszolo.jpg",
                    Informacio = "A medveszőlő egy rendkívül különleges megjelenésű örökzöld növény, melynek élénkpiros termése leginkább a vörös áfonyára hasonlít. " +
                    "A növény levelét és leveles hajtásait lehet hasznosítani gyógyászati célokra, például tea vagy borogatás készítésére.Számos jótékony hatással rendelkezik. " +
                    "Eredményesen kezelhetőek vele a húgyúti megbetegedések, a nőgyógyászati problémák, a magas vérnyomás és a hasmenés, de elősegítheti a sebgyógyulást is. "
                }
                    );
        }


    }
}
