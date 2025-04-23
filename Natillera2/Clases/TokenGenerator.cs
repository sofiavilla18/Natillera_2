using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Natillera2.Clases
{
    public class TokenGenerator
    {
        public static string GenerateTokenJwt(string username)
        {
            // Obtener valores de configuración desde App.config o Web.config
            var secretKey = ConfigurationManager.AppSettings["JWT_SECRET_KEY"];         // Clave secreta para firmar el token
            var audienceToken = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"]; // Público objetivo del token
            var issuerToken = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"];     // Emisor del token
            var expireTime = ConfigurationManager.AppSettings["JWT_EXPIRE_MINUTES"];    // Tiempo de expiración del token (en minutos)

            // Crear clave de seguridad simétrica a partir de la clave secreta
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));

            // Definir las credenciales de firma usando el algoritmo HMAC-SHA256
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // Crear una identidad con claims (en este caso, solo el nombre del usuario)
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) });

            // Crear el token JWT con los parámetros definidos
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,                                                   // A quién va dirigido el token
                issuer: issuerToken,                                                       // Quién emite el token
                subject: claimsIdentity,                                                   // Información del usuario
                notBefore: DateTime.UtcNow,                                                // Desde cuándo es válido
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),         // Fecha de expiración
                signingCredentials: signingCredentials);                                   // Firma digital del token

            // Convertir el token a una cadena en formato JWT (string codificado)
            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);

            // Retornar el token generado como string
            return jwtTokenString;
        }
    }
}