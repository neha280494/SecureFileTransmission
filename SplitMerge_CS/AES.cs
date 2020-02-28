using System;
using System.Security.Cryptography;
using System.IO;

namespace SplitMerge_CS
{
	
	public class AES
	{
		public AES()
		{
		}

		// Encrypt a byte array into a byte array using a key and an IV 
		private  byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV) 
		{ 

			// Create a MemoryStream that is going to accept the encrypted bytes 
			MemoryStream ms = new MemoryStream(); 

			Rijndael alg = Rijndael.Create(); 
    		alg.Key = Key; 

			alg.IV = IV; 
			CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write); 

			cs.Write(clearData, 0, clearData.Length); 
            cs.Close(); 
			byte[] encryptedData = ms.ToArray(); 
  			return encryptedData; 
		} 



		/// <summary>
		/// Returns an encrypted string using Rijndael (128,192,256 Bits).
		/// </summary>
		public string Encrypt(string Data, string Password,int Bits) 
		{ 


			byte[] clearBytes = System.Text.Encoding.Unicode.GetBytes(Data); 

 
			PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,


				new byte[] {0x00, 0x01, 0x02, 0x1C,0x1D,0x1E,0x03,0x04,0x05,0x0F,0x20,0x21,0xAD,0xAF,0xA4}); 
	

			if (Bits == 128)
			{
				byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(16), pdb.GetBytes(16));
				return Convert.ToBase64String(encryptedData);
			}
			else
			{
				return string.Concat(Bits);
			}
    	} 

		// Decrypt a byte array into a byte array using a key and an IV 
		private  byte[] Decrypt(byte[] cipherData, byte[] Key, byte[] IV) 
		{ 

			MemoryStream ms = new MemoryStream(); 
			Rijndael alg = Rijndael.Create(); 
			alg.Key = Key; 
			alg.IV = IV; 
			CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write); 
     		cs.Write(cipherData, 0, cipherData.Length); 
			cs.Close(); 
			byte[] decryptedData = ms.ToArray(); 
			return decryptedData; 
		} 

		
		/// <summary>
		/// Returns a decrypted string.
		/// </summary>
		// Decrypt a string into a string using a password 
		public string Decrypt(string Data, string Password,int Bits) 
		{ 

			byte[] cipherBytes = Convert.FromBase64String(Data); 
  
			PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, 

				new byte[] {0x00, 0x01, 0x02, 0x1C,0x1D,0x1E,0x03,0x04,0x05,0x0F,0x20,0x21,0xAD,0xAF,0xA4}); 
  
			if (Bits == 128)
			{
				byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(16), pdb.GetBytes(16));
				return System.Text.Encoding.Unicode.GetString(decryptedData);
			}
			else
			{
				return string.Concat(Bits);
			}
        
		} 




	}
}
