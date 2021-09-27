using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Util
{
    public class NumeroCartao
    {
        public static int Gerar()
        {
            int num;
            Random randNum = new Random();
            bool valido = false;
            num = randNum.Next();

            return num;
        }
    }
}
