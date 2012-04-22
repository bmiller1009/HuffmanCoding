using System;
using System.IO;
using HuffmanCoding;

namespace Driver
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var hef = new HuffmanEncodeFile("/Users/bfm1009/Desktop/vpn.txt", "/Users/bfm1009/Desktop/vpn.hdef");
			byte[] b = hef.Encode();
			
			File.WriteAllBytes("/Users/bfm1009/Desktop/vpn.hft", b);
			
			byte[] fileBytes = FileHelper.GetFileBytes("/Users/bfm1009/Desktop/vpn.hft");
			
			string bb = hef.Decode(fileBytes);

			File.WriteAllText("/Users/bfm1009/Desktop/vpn2.txt", bb);
		}
	}
}
