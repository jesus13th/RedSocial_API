namespace RedSocial_API.Models {
    public class RedSocialSettings: IRedSocialSettings {
        public string Server { get; set; }
    }
    public interface IRedSocialSettings {
        string Server { get; set; }
    }
}
