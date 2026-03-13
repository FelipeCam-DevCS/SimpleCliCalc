using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraCLI
{
    internal class Program
    {
        /* [AC] A começar [AD] A ser desenvolvido [DC] Desenvolvimento concluido            |
         * ----------------------------------------------------------------------------------\
         * [AC] Plano futuro → substituir o tratamento de exceções por TryParse               |
         * [AC] Plano futuro → adicionar personalização e temas e constancia de configurações |
         * ´---------------------------------------------------------------------------------/
         */
        static void Main(string[] args)
        {
            double? primaryValue = null;
            double secundaryValue;

            ConsoleKeyInfo ckeyinfo; //Declaração de estrutura que armazena a tecla presionada pelo usuario 

            Calculadora calc = new Calculadora();

            //Metodo que inicializa a aparecia do programa
            void StartApparence()
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
            }

            //Metodo que exibe o dialogo de escolha de valor caso o formato seja invalido o Dialogo é exibdo novamente até o valor ser valido
            void DialogCalc()
            {
                Console.Clear();
                if (primaryValue == null) {
                    Console.WriteLine("Escreva o valor primario\n" + 
                        "↓");
                    try
                    {
                        primaryValue = Convert.ToDouble(Console.ReadLine());
                    }
                    catch(System.FormatException)
                    {
                        DialogCalc();
                    }
                }
                Console.WriteLine("Escreva o valor secundario\n" +
                    "↓");
                try
                {
                    secundaryValue = Convert.ToDouble(Console.ReadLine());
                }
                catch (System.FormatException)
                {
                    DialogCalc();
                }
                Console.WriteLine($"| O valor resultante foi → [ {calc.FazerCalculo(ckeyinfo.KeyChar, Convert.ToDouble(primaryValue), secundaryValue)} ]  \n ");
            }

            void DialogUseOldNum()//Dialogo que é exibido caso tenha um resultado armazenado para ser possivel definir o resultado como valor primerio assim podendo dar continuidade ao calculo ou iniciar uma "nova sessão" 
            {
                if (calc.result != null)
                {
                    Console.WriteLine("" +
                        "|Deseja usar o resultado anterior como valor primario?\n" +
                        "   | S → Define o valor primario como o resultado atual\n" +
                        "   | N → Limpa o resultado anterior" +
                        "");

                    ckeyinfo = Console.ReadKey(true);//Ativa a leitura de teclado e salva a tecla pressionada no ckeyinfo

                    Console.Clear();
                    switch (ckeyinfo.KeyChar)
                    {
                        case 'n':
                            primaryValue = Convert.ToDouble(calc.result);
                            break;
                        case 's':
                            calc.result = null;
                            primaryValue = null;
                            break;
                        default:
                            DialogUseOldNum();
                            break;

                    }
                }
            }
            StartApparence();
                Console.WriteLine("Calculadora CLI\n");
                        OpChoice();
           void OpChoice()
            {


                DialogUseOldNum();
                Console.Clear();
                if (calc.result != null)
                {
                    Console.WriteLine($"|Resultado anterior → {Convert.ToString(calc.result)}|");
                }

                Console.WriteLine("" +
                    "| Escolha a operação, use virgulas para decimal:\n" +
                    "    | [ * ] → Multiplicação\n" +
                    "    | [ / ] → Divisão\n" +
                    "    | [ + ] → Adição\n" +
                    "    | [ - ] → Subtração " +
                    "");

                ckeyinfo = Console.ReadKey(true);
                switch (ckeyinfo.KeyChar)
                {
                    case '*':
                        DialogCalc();
                        break;


                    case '/':
                        DialogCalc();

                        break;


                    case '+':
                        DialogCalc();

                        break;


                    case '-':
                        DialogCalc();

                        break;

                    default:
                        OpChoice();
                        break;
                }
            }

               }
            }
          
        }
