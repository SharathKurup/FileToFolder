namespace FileToFolder
{
    public class CREATIONTIME
    {
        public string timestamp = "";
        public string formatted = "";
    }
    public class PHOTOTAKENTIME
    {
        public string timestamp = "";
        public string formatted = "";
    }
    public class GEODATA
    {
        public string latitude = "";
        public string longitude = "";
        public string altitude = "";
        public string latitudeSpan = "";
        public string longitudeSpan = "";
    }
    public class GEODATAEXIF
    {
        public string latitude = "";
        public string longitude = "";
        public string altitude = "";
        public string latitudeSpan = "";
        public string longitudeSpan = "";
    }
    public class DEVICEFOLDER
    {
        public string localFolderName = "";
    }
    public class MOBILEUPLOAD
    {
        public DEVICEFOLDER deviceFolder;
        public string deviceType;
    }
    public class GOOGLEPHOTOSORIGIN
    {
        public MOBILEUPLOAD mobileUpload;
    }
    public class PHOTOLASTMODIFIEDTIME
    {
        public string timestamp = "";
        public string formatted = "";
    }
    internal class FILEPROP
    {
        public string title = "";
        public string description = "";
        public string imageViews = "";
        public CREATIONTIME creationTime;
        public PHOTOTAKENTIME photoTakenTime;
        public GEODATA geoData;
        public GEODATAEXIF geoDataExif;
        public string url = "";
        public GOOGLEPHOTOSORIGIN googlePhotosOrigin;
        public PHOTOLASTMODIFIEDTIME photoLastModifiedTime;
    }
}
