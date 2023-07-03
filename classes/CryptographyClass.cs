using System;
using System.IO;
using System.Text;  
using System.Security.Cryptography;
 
namespace DBTools.classes
{
    /// <summary>
    /// Classe responsável pela criptografia do adados
    /// </summary>
	public static class CryptographyClass
	{	
		private static SymmetricAlgorithm mCSP;
		private static byte[] Key = Encoding.UTF8.GetBytes("%r@i&v$a".Substring(0, 8));  
		private static byte[] IV = {12,16,89,21,48,51,56,34};

        ///// <summary>
        ///// Inicialidador padrão da classe
        ///// </summary>
        //internal CryptographyClass()
        //{
        //    mCSP = new DESCryptoServiceProvider();
        //}
		/// <summary>
		/// Criptografa os dados informados.
		/// </summary>
        /// <param name="text">Texto a criptografar.</param>
		/// <returns>Texto criptografado.</returns>
        public static string Criptografar(string text)
		{     
			try
			{
                mCSP = new DESCryptoServiceProvider();

				ICryptoTransform ct;
				MemoryStream ms;
				CryptoStream cs;
				byte[] byt;
				
				mCSP.Key = Key;
				mCSP.IV = IV;

				ct = mCSP.CreateEncryptor(mCSP.Key, mCSP.IV);

				byt = Encoding.UTF8.GetBytes(text);

				ms = new MemoryStream();
				cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
				cs.Write(byt, 0, byt.Length);
				cs.FlushFinalBlock();

				cs.Close();

				return Convert.ToBase64String(ms.ToArray());
			}
			catch(CryptographicException exc)
			{
				throw exc;
			}
		}
		/// <summary>
		/// Descriptografa os dados informados.
		/// </summary>
        /// <param name="text">Texto a descriptografar.</param>
		/// <returns>Texto descriptografado.</returns>
        public static string Descriptografar(string text)
		{
			try
			{
                mCSP = new DESCryptoServiceProvider();

				ICryptoTransform ct;
				MemoryStream ms;
				CryptoStream cs;
				byte[] byt;
				
				mCSP.Key = Key;
				mCSP.IV = IV;
			
				ct = mCSP.CreateDecryptor(mCSP.Key, mCSP.IV);

                byt = Convert.FromBase64String(text);

				ms = new MemoryStream();
				cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
				cs.Write(byt, 0, byt.Length);
				cs.FlushFinalBlock();

				cs.Close();

				return Encoding.UTF8.GetString(ms.ToArray());
			}
			catch(CryptographicException exc)
			{
				throw exc;
			}
		}
	}
}
