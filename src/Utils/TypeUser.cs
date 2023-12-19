
namespace ShokanApi.Utils
{
    public enum TypeUser
    {
        Administrator,
        Common
    }

    public class TypeUserFormat
    {
        public static string ToString(TypeUser typeUser)
        {
            return typeUser switch
            {
                TypeUser.Administrator => "Administrator",
                TypeUser.Common => "Common",
                _ => throw new Exception("Not found type user"),
            };
        }

        public static TypeUser ToEnum(string typeUser)
        {
            return typeUser switch
            {
                "Administrator" => TypeUser.Administrator,
                "Common" => TypeUser.Common,
                _ => throw new Exception("Not found type user"),
            };
        }
    }
}