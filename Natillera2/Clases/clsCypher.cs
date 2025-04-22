using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Natillera2.Clases
{
    public class clsCypher
    {
        // Propiedad para almacenar la contraseña en texto plano
        public string Password { get; set; }

        // Propiedad donde se guarda la contraseña ya cifrada
        public string PasswordCifrado { get; set; }

        // Propiedad donde se guarda el salt utilizado en el proceso (en formato Base64)
        public string Salt { get; set; }

        // Método que se encarga de cifrar la contraseña y almacenar tanto la contraseña cifrada como el salt
        public bool CifrarClave()
        {
            // Genera un nuevo salt (valor aleatorio que se agrega a la contraseña antes de cifrar)
            byte[] saltBytes = GenerateSalt();

            // Cifra la contraseña combinada con el salt
            PasswordCifrado = HashPassword(Password, saltBytes);

            // Guarda el salt en formato Base64 (texto legible) para poder reutilizarlo si se necesita validar la contraseña después
            Salt = Convert.ToBase64String(saltBytes);

            return true; // Indica que la operación fue exitosa
        }

        // Método que aplica el hash SHA-256 a una contraseña combinada con un salt
        public string HashPassword(string password, byte[] salt)
        {
            using (var sha256 = new SHA256Managed()) // Instancia del algoritmo SHA-256
            {
                // Convierte la contraseña a bytes
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // Crea un nuevo arreglo de bytes que contendrá la contraseña y el salt juntos
                byte[] saltedPassword = new byte[passwordBytes.Length + salt.Length];

                // Copia los bytes de la contraseña al nuevo arreglo
                Buffer.BlockCopy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);

                // Añade los bytes del salt al final del arreglo
                Buffer.BlockCopy(salt, 0, saltedPassword, passwordBytes.Length, salt.Length);

                // Aplica el hash a la contraseña combinada con el salt
                byte[] hashedBytes = sha256.ComputeHash(saltedPassword);

                // Junta el salt original con el hash para almacenarlo todo junto
                byte[] hashedPasswordWithSalt = new byte[hashedBytes.Length + salt.Length];
                Buffer.BlockCopy(salt, 0, hashedPasswordWithSalt, 0, salt.Length);
                Buffer.BlockCopy(hashedBytes, 0, hashedPasswordWithSalt, salt.Length, hashedBytes.Length);

                // Devuelve el resultado en una cadena codificada en Base64 (lista para almacenar)
                return Convert.ToBase64String(hashedPasswordWithSalt);
            }
        }

        // Método que genera un salt aleatorio de 16 bytes
        static byte[] GenerateSalt()
        {
            using (var rng = new RNGCryptoServiceProvider()) // Generador criptográficamente seguro
            {
                byte[] salt = new byte[16]; // Tamaño del salt (puedes cambiarlo según el nivel de seguridad deseado)
                rng.GetBytes(salt); // Llena el arreglo con bytes aleatorios
                return salt;
            }
        }
    }
}
