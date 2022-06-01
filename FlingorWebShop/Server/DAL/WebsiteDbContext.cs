using FlingorWebShop.Shared;
using Microsoft.EntityFrameworkCore;

namespace FlingorWebShop.Server.DAL
{
    public class WebsiteDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }

        public WebsiteDbContext(DbContextOptions options) : base(options)
        {

        }

        //We "insert" pre-made data here. Populates the database with this data every time we update database.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    ArticleNumber = "001",
                    Title = "Minecraft",
                    ReleaseDate = new DateTime(2011, 11, 18),
                    AgeRating = AgeRating.PEGI_3,
                    Price = 200,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Xbox Game Studios",
                    Genre = Genre.Adventure
                },
                new Product
                {
                    Id = 2,
                    ArticleNumber = "002",
                    Title = "Grand Theft Auto V",
                    ReleaseDate = new DateTime(2013, 09, 17),
                    AgeRating = AgeRating.PEGI_18,
                    Price = 600,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Rockstar Games",
                    Genre = Genre.Shooter
                },
                new Product
                {
                    Id = 3,
                    ArticleNumber = "003",
                    Title = "Balloon-Man and the Incredible Balloon",
                    ReleaseDate = new DateTime(2022, 04, 4),
                    AgeRating = AgeRating.PEGI_3,
                    Price = 1,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Viktor&Tobias",
                    Genre = Genre.Adventure
                },
                new Product
                {
                    Id = 4,
                    ArticleNumber = "004",
                    Title = "Tetris (EA)",
                    ReleaseDate = new DateTime(2006, 09, 12),
                    AgeRating = AgeRating.PEGI_3,
                    Price = 100,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Electronic Arts",
                    Genre = Genre.Strategy
                },
                new Product
                {
                    Id = 5,
                    ArticleNumber = "005",
                    Title = "Wii Sports",
                    ReleaseDate = new DateTime(2006, 11, 19),
                    AgeRating = AgeRating.PEGI_7,
                    Price = 200,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Nintendo",
                    Genre = Genre.Action
                },
                new Product
                {
                    Id = 6,
                    ArticleNumber = "006",
                    Title = "PUBG: Battlegrounds",
                    ReleaseDate = new DateTime(2017, 12, 20),
                    AgeRating = AgeRating.PEGI_18,
                    Price = 300,
                    AmountInStock = new Random().Next(100),
                    Publisher = "PUBG Corporation",
                    Genre = Genre.Shooter
                },
                new Product
                {
                    Id = 7,
                    ArticleNumber = "007",
                    Title = "Super Mario Bros.",
                    ReleaseDate = new DateTime(1985, 09, 13),
                    AgeRating = AgeRating.PEGI_3,
                    Price = 400,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Nintendo",
                    Genre = Genre.Adventure
                },
                new Product
                {
                    Id = 8,
                    ArticleNumber = "008",
                    Title = "Mario Kart 8",
                    ReleaseDate = new DateTime(2014, 04, 5),
                    AgeRating = AgeRating.PEGI_7,
                    Price = 600,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Nintendo",
                    Genre = Genre.Action
                },
                new Product
                {
                    Id = 9,
                    ArticleNumber = "009",
                    Title = "Pokémon Red",
                    ReleaseDate = new DateTime(1996, 02, 27),
                    AgeRating = AgeRating.PEGI_12,
                    Price = 500,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Nintendo",
                    Genre = Genre.Adventure
                },
                new Product
                {
                    Id = 10,
                    ArticleNumber = "010",
                    Title = "Pokémon Green",
                    ReleaseDate = new DateTime(1996, 02, 27),
                    AgeRating = AgeRating.PEGI_12,
                    Price = 500,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Nintendo",
                    Genre = Genre.Adventure
                },
                new Product
                {
                    Id = 11,
                    ArticleNumber = "011",
                    Title = "Pokémon Blue",
                    ReleaseDate = new DateTime(1996, 02, 27),
                    AgeRating = AgeRating.PEGI_12,
                    Price = 500,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Nintendo",
                    Genre = Genre.Adventure
                },
                new Product
                {
                    Id = 12,
                    ArticleNumber = "012",
                    Title = "Pokémon Yellow",
                    ReleaseDate = new DateTime(1996, 02, 27),
                    AgeRating = AgeRating.PEGI_12,
                    Price = 500,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Nintendo",
                    Genre = Genre.Adventure
                },
                new Product
                {
                    Id = 13,
                    ArticleNumber = "013",
                    Title = "Wii Fit",
                    ReleaseDate = new DateTime(2007, 12, 1),
                    AgeRating = AgeRating.PEGI_3,
                    Price = 400,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Nintendo",
                    Genre = Genre.Adventure
                },
                new Product
                {
                    Id = 14,
                    ArticleNumber = "014",
                    Title = "Red Dead Redemption 2",
                    ReleaseDate = new DateTime(2018, 10, 26),
                    AgeRating = AgeRating.PEGI_18,
                    Price = 600,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Rockstar Games",
                    Genre = Genre.Adventure
                },
                new Product
                {
                    Id = 15,
                    ArticleNumber = "015",
                    Title = "Tetris (Nintendo)",
                    ReleaseDate = new DateTime(1989, 06, 14),
                    AgeRating = AgeRating.PEGI_3,
                    Price = 200,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Nintendo",
                    Genre = Genre.Strategy
                },
                new Product
                {
                    Id = 16,
                    ArticleNumber = "016",
                    Title = "Pac-Man",
                    ReleaseDate = new DateTime(1980, 05, 22),
                    AgeRating = AgeRating.PEGI_3,
                    Price = 200,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Nintendo",
                    Genre = Genre.Strategy
                },
                new Product
                {
                    Id = 17,
                    ArticleNumber = "017",
                    Title = "Mario Kart Wii",
                    ReleaseDate = new DateTime(2008, 04, 10),
                    AgeRating = AgeRating.PEGI_3,
                    Price = 500,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Nintendo",
                    Genre = Genre.Strategy
                },
                new Product
                {
                    Id = 18,
                    ArticleNumber = "018",
                    Title = "Elden Ring",
                    ReleaseDate = new DateTime(2002, 02, 25),
                    AgeRating = AgeRating.PEGI_16,
                    Price = 600,
                    AmountInStock = new Random().Next(100),
                    Publisher = "FROMSoft",
                    Genre = Genre.Adventure
                }, new Product
                {
                    Id = 19,
                    ArticleNumber = "019",
                    Title = "Terraria",
                    ReleaseDate = new DateTime(2011, 05, 16),
                    AgeRating = AgeRating.PEGI_7,
                    Price = 200,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Re-Logic",
                    Genre = Genre.Adventure
                },
                new Product
                {
                    Id = 20,
                    ArticleNumber = "020",
                    Title = "Wii Sports Resort",
                    ReleaseDate = new DateTime(2009, 06, 25),
                    AgeRating = AgeRating.PEGI_3,
                    Price = 500,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Nintendo",
                    Genre = Genre.Adventure
                },
                new Product
                {
                    Id = 21,
                    ArticleNumber = "021",
                    Title = "New Super Mario Bros.",
                    ReleaseDate = new DateTime(2006, 05, 16),
                    AgeRating = AgeRating.PEGI_3,
                    Price = 500,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Nintendo",
                    Genre = Genre.Adventure
                },
                new Product
                {
                    Id = 22,
                    ArticleNumber = "022",
                    Title = "New Super Mario Bros. Wii",
                    ReleaseDate = new DateTime(2009, 11, 11),
                    AgeRating = AgeRating.PEGI_3,
                    Price = 500,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Nintendo",
                    Genre = Genre.Strategy
                },
                new Product
                {
                    Id = 23,
                    ArticleNumber = "023",
                    Title = "The Elder Scrolls V: Skyrim",
                    ReleaseDate = new DateTime(2011, 11, 11),
                    AgeRating = AgeRating.PEGI_18,
                    Price = 600,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Bethesda Softworks",
                    Genre = Genre.Adventure
                },
                new Product
                {
                    Id = 24,
                    ArticleNumber = "024",
                    Title = "Call of Duty: Modern Warfare",
                    ReleaseDate = new DateTime(2019, 10, 25),
                    AgeRating = AgeRating.PEGI_18,
                    Price = 600,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Activision",
                    Genre = Genre.Shooter
                },
                new Product
                {
                    Id = 25,
                    ArticleNumber = "025",
                    Title = "Diablo III",
                    ReleaseDate = new DateTime(2012, 05, 16),
                    AgeRating = AgeRating.PEGI_3,
                    Price = 500,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Blizzard Entertainment",
                    Genre = Genre.Action
                },
                new Product
                {
                    Id = 26,
                    ArticleNumber = "026",
                    Title = "The Witcher 3",
                    ReleaseDate = new DateTime(2015, 05, 19),
                    AgeRating = AgeRating.PEGI_18,
                    Price = 600,
                    AmountInStock = new Random().Next(100),
                    Publisher = "CD Projekt",
                    Genre = Genre.Adventure
                },
                new Product
                {
                    Id = 27,
                    ArticleNumber = "027",
                    Title = "Human: Fall Flat",
                    ReleaseDate = new DateTime(2016, 07, 22),
                    AgeRating = AgeRating.PEGI_3,
                    Price = 200,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Curve Digital",
                    Genre = Genre.Adventure
                },
                new Product
                {
                    Id = 28,
                    ArticleNumber = "028",
                    Title = "Pokémon Gold",
                    ReleaseDate = new DateTime(1999, 11, 21),
                    AgeRating = AgeRating.PEGI_12,
                    Price = 200,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Nintendo",
                    Genre = Genre.Adventure
                },
                new Product
                {
                    Id = 29,
                    ArticleNumber = "029",
                    Title = "Pokémon Silver",
                    ReleaseDate = new DateTime(1999, 11, 21),
                    AgeRating = AgeRating.PEGI_12,
                    Price = 200,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Nintendo",
                    Genre = Genre.Adventure
                },
                new Product
                {
                    Id = 30,
                    ArticleNumber = "030",
                    Title = "Pokémon Crystal",
                    ReleaseDate = new DateTime(1999, 11, 21),
                    AgeRating = AgeRating.PEGI_12,
                    Price = 200,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Nintendo",
                    Genre = Genre.Adventure
                },
                new Product
                {
                    Id = 31,
                    ArticleNumber = "031",
                    Title = "Duck Hunt",
                    ReleaseDate = new DateTime(1994, 04, 21),
                    AgeRating = AgeRating.PEGI_3,
                    Price = 200,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Nintendo",
                    Genre = Genre.Shooter
                },
                new Product
                {
                    Id = 32,
                    ArticleNumber = "032",
                    Title = "Wii Play",
                    ReleaseDate = new DateTime(2006, 12, 02),
                    AgeRating = AgeRating.PEGI_3,
                    Price = 400,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Nintendo",
                    Genre = Genre.Adventure
                },
                new Product
                {
                    Id = 33,
                    ArticleNumber = "033",
                    Title = "Grand Theft Auto: San Andreas",
                    ReleaseDate = new DateTime(2004, 10, 26),
                    AgeRating = AgeRating.PEGI_18,
                    Price = 200,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Rockstart Games",
                    Genre = Genre.Strategy
                },
                new Product
                {
                    Id = 34,
                    ArticleNumber = "034",
                    Title = "The Legend of Zelda: Breath of the Wild",
                    ReleaseDate = new DateTime(2017, 03, 3),
                    AgeRating = AgeRating.PEGI_12,
                    Price = 600,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Nintendo",
                    Genre = Genre.Adventure
                },
                new Product
                {
                    Id = 35,
                    ArticleNumber = "035",
                    Title = "Super Smash Bros. Ultimate",
                    ReleaseDate = new DateTime(2018, 12, 07),
                    AgeRating = AgeRating.PEGI_12,
                    Price = 600,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Nintendo",
                    Genre = Genre.Strategy
                },
                new Product
                {
                    Id = 36,
                    ArticleNumber = "036",
                    Title = "Super Mario World",
                    ReleaseDate = new DateTime(1990, 11, 21),
                    AgeRating = AgeRating.PEGI_3,
                    Price = 300,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Nintendo",
                    Genre = Genre.Adventure
                },
                new Product
                {
                    Id = 37,
                    ArticleNumber = "037",
                    Title = "Call of Duty: Modern Warfare 3",
                    ReleaseDate = new DateTime(2011, 11, 08),
                    AgeRating = AgeRating.PEGI_18,
                    Price = 400,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Activision",
                    Genre = Genre.Shooter
                },
                new Product
                {
                    Id = 38,
                    ArticleNumber = "038",
                    Title = "Call of Duty: Black Ops",
                    ReleaseDate = new DateTime(2010, 11, 9),
                    AgeRating = AgeRating.PEGI_18,
                    Price = 400,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Activision",
                    Genre = Genre.Shooter
                },
                new Product
                {
                    Id = 39,
                    ArticleNumber = "039",
                    Title = "Borderlands 2",
                    ReleaseDate = new DateTime(2012, 09, 18),
                    AgeRating = AgeRating.PEGI_18,
                    Price = 400,
                    AmountInStock = new Random().Next(100),
                    Publisher = "2K Games",
                    Genre = Genre.Strategy
                },
                new Product
                {
                    Id = 40,
                    ArticleNumber = "040",
                    Title = "Pokémon Sun",
                    ReleaseDate = new DateTime(2016, 10, 18),
                    AgeRating = AgeRating.PEGI_12,
                    Price = 300,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Nintendo",
                    Genre = Genre.Adventure
                },
                new Product
                {
                    Id = 41,
                    ArticleNumber = "041",
                    Title = "Pokémon Moon",
                    ReleaseDate = new DateTime(2016, 10, 18),
                    AgeRating = AgeRating.PEGI_12,
                    Price = 300,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Nintendo",
                    Genre = Genre.Adventure
                },
                new Product
                {
                    Id = 42,
                    ArticleNumber = "042",
                    Title = "Grand Theft Auto IV",
                    ReleaseDate = new DateTime(2008, 04, 29),
                    AgeRating = AgeRating.PEGI_18,
                    Price = 400,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Rockstar Games",
                    Genre = Genre.Shooter
                },
                new Product
                {
                    Id = 43,
                    ArticleNumber = "043",
                    Title = "Pokémon Diamond",
                    ReleaseDate = new DateTime(2006, 09, 28),
                    AgeRating = AgeRating.PEGI_3,
                    Price = 345,
                    AmountInStock = new Random().Next(100),
                    Publisher = "FROMSoft",
                    Genre = Genre.Strategy
                },
                new Product
                {
                    Id = 44,
                    ArticleNumber = "044",
                    Title = "Super Mario Bros. 3",
                    ReleaseDate = new DateTime(1988, 09, 23),
                    AgeRating = AgeRating.PEGI_3,
                    Price = 300,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Nintendo",
                    Genre = Genre.Adventure
                },
                new Product
                {
                    Id = 45,
                    ArticleNumber = "045",
                    Title = "Call of Duty: Black Ops II",
                    ReleaseDate = new DateTime(2012, 11, 12),
                    AgeRating = AgeRating.PEGI_18,
                    Price = 400,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Activision",
                    Genre = Genre.Shooter
                },
                new Product
                {
                    Id = 46,
                    ArticleNumber = "046",
                    Title = "Kinect Adventures!",
                    ReleaseDate = new DateTime(2010, 11, 4),
                    AgeRating = AgeRating.PEGI_3,
                    Price = 345,
                    AmountInStock = new Random().Next(100),
                    Publisher = "FROMSoft",
                    Genre = Genre.Strategy
                },
                new Product
                {
                    Id = 47,
                    ArticleNumber = "047",
                    Title = "FIFA 18",
                    ReleaseDate = new DateTime(2017, 09, 29),
                    AgeRating = AgeRating.PEGI_7,
                    Price = 600,
                    AmountInStock = new Random().Next(100),
                    Publisher = "EA Sports",
                    Genre = Genre.Strategy
                },
                new Product
                {
                    Id = 48,
                    ArticleNumber = "048",
                    Title = "Sonic the Hedgehog",
                    ReleaseDate = new DateTime(1991, 06, 23),
                    AgeRating = AgeRating.PEGI_3,
                    Price = 200,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Sega",
                    Genre = Genre.Adventure
                },
                new Product
                {
                    Id = 49,
                    ArticleNumber = "049",
                    Title = "Nintendogs",
                    ReleaseDate = new DateTime(2005, 04, 21),
                    AgeRating = AgeRating.PEGI_3,
                    Price = 300,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Nintendo",
                    Genre = Genre.Strategy
                },
                new Product
                {
                    Id = 50,
                    ArticleNumber = "050",
                    Title = "Mario Kart DS",
                    ReleaseDate = new DateTime(2005, 11, 14),
                    AgeRating = AgeRating.PEGI_3,
                    Price = 400,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Nintendo",
                    Genre = Genre.Adventure
                },
                new Product
                {
                    Id = 51,
                    ArticleNumber = "051",
                    Title = "Pusheen Mouse mat",
                    ReleaseDate = new DateTime(2005, 11, 14),
                    AgeRating = 0,
                    Price = 200,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Pusheen",
                    Genre = Genre.Adventure,
                    Type = Types.Accessory
                },
                new Product
                {
                    Id = 52,
                    ArticleNumber = "052",
                    Title = "Logitech G240 Gaming Mouse Pad",
                    ReleaseDate = new DateTime(2005, 11, 14),
                    AgeRating = 0,
                    Price = 200,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Logitech",
                    Genre = Genre.Adventure,
                    Type = Types.Accessory
                },
                new Product
                {
                    Id = 53,
                    ArticleNumber = "053",
                    Title = "Pro Gamer Mouse",
                    ReleaseDate = new DateTime(2005, 11, 14),
                    AgeRating = 0,
                    Price = 110,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Joom",
                    Genre = Genre.Adventure,
                    Type = Types.Accessory
                },
                new Product
                {
                    Id = 54,
                    ArticleNumber = "054",
                    Title = "Razer DeathAdder V2 Pro - Genshin Impact Edition",
                    ReleaseDate = new DateTime(2005, 11, 14),
                    AgeRating = 0,
                    Price = 1500,
                    AmountInStock = new Random().Next(100),
                    Publisher = "Razer",
                    Genre = Genre.Adventure,
                    Type = Types.Accessory
                },
                new Product
                {
                    Id = 55,
                    ArticleNumber = "055",
                    Title = "Keep Out Gaming Headset Med Mikrofon HX901 7.1",
                    ReleaseDate = new DateTime(2005, 11, 14),
                    AgeRating = 0,
                    Price = 400,
                    AmountInStock = new Random().Next(100),
                    Publisher = "techINN",
                    Genre = Genre.Adventure,
                    Type = Types.Accessory
                },
                new Product
                {
                    Id = 56,
                    ArticleNumber = "056",
                    Title = "Cat Ear Wired Gaming Headset LED",
                    ReleaseDate = new DateTime(2005, 11, 14),
                    AgeRating = 0,
                    Price = 300,
                    AmountInStock = new Random().Next(100),
                    Publisher = "AGENI",
                    Genre = Genre.Adventure,
                    Type = Types.Accessory
                },
                new Product
                {
                    Id = 57,
                    ArticleNumber = "057",
                    Title = "Corsair K70 MK.2 RGB tangentbord gaming",
                    ReleaseDate = new DateTime(2005, 11, 14),
                    AgeRating = 0,
                    Price = 1700,
                    AmountInStock = new Random().Next(100),
                    Publisher = "CORSAIR",
                    Genre = Genre.Adventure,
                    Type = Types.Accessory
                },
                new Product
                {
                    Id = 58,
                    ArticleNumber = "058",
                    Title = "BLITZWOLF BW-KB1 GAMER KEYBOARD",
                    ReleaseDate = new DateTime(2005, 11, 14),
                    AgeRating = 0,
                    Price = 700,
                    AmountInStock = new Random().Next(100),
                    Publisher = "BLITZWOLF",
                    Genre = Genre.Adventure,
                    Type = Types.Accessory
                },
                new Product
                {
                    Id = 59,
                    ArticleNumber = "059",
                    Title = "Gamvis FURIOSO Ladies’ Fabric Gaming Chair – Black/Pink/White",
                    ReleaseDate = new DateTime(2005, 11, 14),
                    AgeRating = 0,
                    Price = 2800,
                    AmountInStock = new Random().Next(100),
                    Publisher = "GAMVIS",
                    Genre = Genre.Adventure,
                    Type = Types.Accessory
                },
                new Product
                {
                    Id = 60,
                    ArticleNumber = "060",
                    Title = "ARGENT E700 Real Leather Gaming Chair",
                    ReleaseDate = new DateTime(2005, 11, 14),
                    AgeRating = 0,
                    Price = 10000,
                    AmountInStock = new Random().Next(100),
                    Publisher = "thermaltake",
                    Genre = Genre.Adventure,
                    Type = Types.Accessory
                }
            );
            modelBuilder.Entity<User>().HasData(
                //Creates a admin with login email "admin@ad.min" and password "admin".
                new User
                {
                    Id = 1,
                    Email = "admin@ad.min",
                    Password = "admin",
                    PasswordHash = Convert.FromHexString("296780E3CF0824643417F03941E8F00C8E864DC31C4EEDA4320CB2C2E5B6494DB50A38A79103D429601E776EA4AB786DEE7A0BBC243C460E05CD6F692F5FC7FF"),
                    PasswordSalt = Convert.FromHexString("EFF3924C861A4A38315307C346889C9BAEBB6BA41FFA2B8D8C2A6B8C47065360E0F4FF4D237B7E79B97367FBAEA7B44BC705934E589896B535B9E6483E3A42D49FE6CE1E10B8850493888154A9639B1EF9CBAEE561E1CF57BD3C73F6979A8ACA6BE1DCAB68B7629E6F25D7B95D52CFBDD7992EE63C8DE029CF158BDB7629BA9C"),
                    Phone = "0706923052",
                    FirstName = "Ad",
                    LastName = "Min",
                     StreetName = "Hålträdet",
                    StreetNumber = "5",
                     City = "Göteborg",
                    State = "",
                    PostalCode = "44238",
                    Country = "Sweden",
                    IsAdmin = true,
                }
            );
        }
    }
}
