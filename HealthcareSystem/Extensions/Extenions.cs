using Microsoft.CodeAnalysis.Scripting;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Reflection;

namespace HealthcareSystem.Extensions
{
    public class Extenions
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
        public static void CopyObjectData<TLeft, TRight>(TLeft source, TRight destination)
        {
            // Lấy danh sách các thuộc tính của đối tượng nguồn
            PropertyInfo[] properties = typeof(TLeft).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                // Kiểm tra xem thuộc tính có thể đọc và có giá trị hay không
                if (property.CanRead)
                {
                    // Lấy giá trị từ đối tượng nguồn
                    object value = property.GetValue(source);

                    // Kiểm tra giá trị không rỗng trước khi sao chép
                    if (value != null)
                    {
                        // Kiểm tra xem thuộc tính có tồn tại trong đối tượng đích không
                        PropertyInfo correspondingProperty = typeof(TRight).GetProperty(property.Name);
                        if (correspondingProperty != null && correspondingProperty.CanWrite)
                        {
                            // Thiết lập giá trị vào đối tượng đích
                            correspondingProperty.SetValue(destination, value);
                        }
                    }
                }
            }
        }

    }
}
