using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraCLI
{
    internal class Calculadora
    {
        public double? result = null;


        //Fazer calculo é um metodo que retorna o resultado conforme o primeiro valor e segundo valor do paremetro e realiza o calculo seguindo o O Op (operador inserido pelo tipo char(caractere))
        public double FazerCalculo(Char Op, double firstValue, double secondValue) { 
             double resultMet;
            switch (Op)
                {
             
                    case '/':

                    try
                    { 
                    resultMet = firstValue / secondValue;
                    }
                    catch(DivideByZeroException)
                    {
                        return 0;
                    }
                    result = resultMet;
                        return resultMet;
                    
                    
                    
                    case '*':
                    resultMet = firstValue * secondValue;
                    result = resultMet;
                    return resultMet;


                    case '-':
                    resultMet = firstValue - secondValue;
                    result = resultMet;
                    return resultMet;


                    case '+':
                    resultMet = firstValue + secondValue;
                    result = resultMet;
                    return resultMet; 

                    default: 
                        return 1;
             }          
            
         }
    }
}
