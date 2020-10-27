using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp1.Hashing
{
    class MyHMAC
    {
        private HMAC hashingAlgo;
        //public void HashBytes(byte[] passToHas)
        //{

        //}
        public byte[] HashBytes(byte[] passToHas, byte[] hashKey)
        {
            hashingAlgo.Key = hashKey;
            byte[] value = hashingAlgo.ComputeHash(passToHas);
            return value;
        }
        public bool CheckAuth(byte[] msg, byte[] mac, byte[] key)
        {
            hashingAlgo.Key = key;
            if (ByteLoob(hashingAlgo.ComputeHash(msg), mac, (hashingAlgo.HashSize / 8)))
                return false;
            else
                return true;
        }
        public bool ByteLoob(byte[] hashedMsg, byte[] revicemsg, int length)
        {
            for (int i = 0; i < length; i++)
            {
                if (revicemsg[i] != hashedMsg[i])
                    return false;
            }
            return true;
        }
        public void HashToUse(int hashToUse)
        {
            switch (hashToUse)
            {
                case 1:
                    hashingAlgo = new HMACMD5();
                    break;
                case 2:
                    hashingAlgo = new HMACSHA1();
                    break;
                case 3:
                    hashingAlgo = new HMACSHA256();
                    break;
                case 4:
                    hashingAlgo = new HMACSHA512();
                    break;
                default:
                    hashingAlgo = new HMACMD5();
                    break;

            }
        }
    }
}
