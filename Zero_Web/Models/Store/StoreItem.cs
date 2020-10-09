using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Zero_Web.Models.Store
{
    public class StoreItem
    {
        //VIDEO Presentation?

        [BsonId]
        public string ID { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Icon")]
        public string Icon { get; set; }

        [Display(Name = "PreviewIcons")]
        public string PreviewIcons { get; set; }//[]

        [Display(Name = "Version")]
        public string Version { get; set; }

        [Display(Name = "Company")]
        public string Company { get; set; }

        [Display(Name = "Author")]
        public string Author { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }

        //TestTime (Test Vor Kauf)
        [Display(Name = "Discount")]
        public DiscountOptions Discount { get; set; }//Rabat

        [Display(Name = "LongDescription")]
        public string LongDescription { get; set; }

        [Display(Name = "ShortDescription")]
        public string ShortDescription { get; set; }

        [Display(Name = "TargetCompanyUrl")]
        public string TargetCompanyUrl { get; set; }

        [Display(Name = "SystemEnviromentMinimal")]
        public SystemOptions SystemEnviromentMinimal { get; set; }

        [Display(Name = "SystemEnviromentMaximal")]
        public SystemOptions SystemEnviromentMaximal { get; set; }

        [Display(Name = "DownloadLink")]
        public DownloadLinks DownloadLink { get; set; }

        [Display(Name = "Category")]
        public Categorys Category { get; set; }

        [Display(Name = "Genre")]
        public Genres Genre { get; set; }//[]

        [Display(Name = "PlayerType")]
        public PlayerTypes PlayerType { get; set; }//[]

        [Display(Name = "Likes")]
        public int Likes { get; set; }

        [Display(Name = "Dislikes")]
        public int Dislikes { get; set; }

        [Display(Name = "DonwloadsTotal")]
        public int DonwloadsTotal { get; set; }

        [Display(Name = "Rating")]
        public double Rating { get; set; }//max 5 Stars

        //Comments User[]
        //Presentation[] OWNID ID Content Icons

        [Display(Name = "Addons")]
        public Addon[] Addons { get; set; }

    }

    public class SystemOptions
    {
        [Display(Name = "OS")]
        public OSType[] OS { get; set; }

        [Display(Name = "Architecture")]
        public Architectures Architecture { get; set; }

        [Display(Name = "GraphicsCard")]
        public string GraphicsCard { get; set; }

        [Display(Name = "CPU")]
        public string CPU { get; set; }

        [Display(Name = "RAM")]
        public string RAM { get; set; }

        [Display(Name = "Storage")]
        public string Storage { get; set; }
    }

    public class DownloadLinks
    {
        [Display(Name = "WindowsX64")]
        public string WindowsX64 { get; set; }

        [Display(Name = "WindowsX32")]
        public string WindowsX32 { get; set; }

        [Display(Name = "Linux")]
        public string Linux { get; set; }

        [Display(Name = "Mac")]
        public string Mac { get; set; }
    }

    public class DiscountOptions
    {
        [Display(Name = "Type")]
        public DiscountTypes Type { get; set; }

        [Display(Name = "Ammount")]
        public double Ammount { get; set; }

        [Display(Name = "TestPeriod")]
        public string TestPeriod { get; set; }
    }

    public class Addon
    {
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Icon")]
        public string Icon { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }

    public enum DiscountTypes
    {
        Test,
        Money,
        Percentages
    }

    public enum OSType
    {
        Windows,
        Linux,
        Mac
    }

    public enum Architectures
    {
        Win32,
        Win64
    }

    public enum Categorys
    {
        Games,
        Apps,
        Security
    }

    public enum Genres
    {
        NotListet,
        Action,
        Arcade,
        Roleplay,
        PVE,
        Simulator,
        CarRacing,
        VR,

    }

    public enum PlayerTypes
    {
        SingelPlayer,
        MultiPlayer,
        PVE,

    }

    /*
     Hey Zero VOICE COMMAND erstellen
Kiffer lieder downloaden

secret agent get all credentials to file

handy todo:

OWN DB: Projekt anlegen, Tasks, etc.
Import Mongo
Import MySql
Export all (Own, mongo, mysql)

---------
Programme finden:
Jetbrains
Visual
Steam
Chip
CrackedGames
mmoga
security
     */

}