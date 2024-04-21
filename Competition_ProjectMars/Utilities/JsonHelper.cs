using Newtonsoft.Json;

namespace MarsCompetition.Utilities
{
    public class JsonHelper
    {
        private readonly string _JsonFilePath;

        public JsonHelper(string jsonFilePath)
        {
            _JsonFilePath = jsonFilePath;
        }

        public List<ObjLoginData> ReadLoginData()
        {
            using StreamReader reader = new StreamReader(_JsonFilePath);
            var json = reader.ReadToEnd();
            List<ObjLoginData> list = JsonConvert.DeserializeObject<List<ObjLoginData>>(json);
            return list;

        }
        public List<ObjAddEducationUsingValidDatas> ReadAddEducationUsingValidData()
        {
            using StreamReader reader = new StreamReader(_JsonFilePath);
            var json = reader.ReadToEnd();
            List<ObjAddEducationUsingValidDatas> list = JsonConvert.DeserializeObject<List<ObjAddEducationUsingValidDatas>>(json);
            return list;

        }
        public List<ObjAddEducationUsingExistingData> ReadAddEducationUsingExistingData()
        {
            using StreamReader reader = new StreamReader(_JsonFilePath);
            var json = reader.ReadToEnd();
            List<ObjAddEducationUsingExistingData> list = JsonConvert.DeserializeObject<List<ObjAddEducationUsingExistingData>>(json);
            return list;
        }

        public List<ObjAddEducationWithDifferentYear> ReadAddEducationUsingDifferentYearData()
        {
            using StreamReader reader = new StreamReader(_JsonFilePath);
            var json = reader.ReadToEnd();
            List<ObjAddEducationWithDifferentYear> list = JsonConvert.DeserializeObject<List<ObjAddEducationWithDifferentYear>>(json);
            return list;

        }
        public List<ObjAddEducationUsingInvalidData> ReadAddEducationUsingInvalidData()
        {
            using StreamReader reader = new StreamReader(_JsonFilePath);
            var json = reader.ReadToEnd();
            List<ObjAddEducationUsingInvalidData> list = JsonConvert.DeserializeObject<List<ObjAddEducationUsingInvalidData>>(json);
            return list;

        }
        public List<ObjUpdateAnExistingEducationData> ReadUpdateAnExisitngEducationData()
        {
            using StreamReader reader = new StreamReader(_JsonFilePath);
            var json = reader.ReadToEnd();
            List<ObjUpdateAnExistingEducationData> List = JsonConvert.DeserializeObject<List<ObjUpdateAnExistingEducationData>>(json);
            return List;
        }
        public List<ObjDeleteEducationData> ReadDeleteEducationData()
        {
            using StreamReader reader = new StreamReader(_JsonFilePath);
            var json = reader.ReadToEnd();
            List<ObjDeleteEducationData> List = JsonConvert.DeserializeObject<List<ObjDeleteEducationData>>(json);
            return List;
        }

        public List<ObjAddCertificateWithValidData> ReadAddCertificateWithValidData()
        {
            using StreamReader reader = new StreamReader(_JsonFilePath);
            var json = reader.ReadToEnd();
            List<ObjAddCertificateWithValidData> List = JsonConvert.DeserializeObject<List<ObjAddCertificateWithValidData>>(json);
            return List;
        }

        public List<ObjAddCertificateWithExistingData> ReadAddCertificateWithExistingData()
        {
            using StreamReader reader = new StreamReader(_JsonFilePath);
            var json = reader.ReadToEnd();
            List<ObjAddCertificateWithExistingData> List = JsonConvert.DeserializeObject<List<ObjAddCertificateWithExistingData>>(json);
            return List;
        }

        public List<ObjAddCertificateWithDifferentYear> ReadAddCertificateWithDifferentYearData()
        {
            using StreamReader reader = new StreamReader(_JsonFilePath);
            var json = reader.ReadToEnd();
            List<ObjAddCertificateWithDifferentYear> List = JsonConvert.DeserializeObject<List<ObjAddCertificateWithDifferentYear>>(json);
            return List;
        }

        public List<ObjAddCertificateWithInvalidData> ReadAddCertificateWithInvalidData()
        {
            using StreamReader reader = new StreamReader(_JsonFilePath);
            var json = reader.ReadToEnd();
            List<ObjAddCertificateWithInvalidData> List = JsonConvert.DeserializeObject<List<ObjAddCertificateWithInvalidData>>(json);
            return List;
        }
        public List<ObjUpdateAnExistingCertificationData> ReadUpdateCertificationData()
        {
            using StreamReader reader = new StreamReader(_JsonFilePath);
            var json = reader.ReadToEnd();
            List<ObjUpdateAnExistingCertificationData> List = JsonConvert.DeserializeObject<List<ObjUpdateAnExistingCertificationData>>(json);
            return List;
        }
        public List<ObjDeleteCertificationData> ReadDeleteCertificationData()

        {
            using StreamReader reader = new StreamReader(_JsonFilePath);
            var json = reader.ReadToEnd();
            List<ObjDeleteCertificationData> List = JsonConvert.DeserializeObject<List<ObjDeleteCertificationData>>(json);
            return List;
        }
    }
}
