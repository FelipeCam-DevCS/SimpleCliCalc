using System;
using System.CodeDom.Compiler;
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

            bool continuar = true;
            bool UserValueCatcher = true;
            bool invaSeleCont = true;
            bool UseOldNumDialog = true;

            ConsoleKeyInfo ckeyinfo = new ConsoleKeyInfo(); //Declaração de estrutura que armazena a tecla presionada pelo usuario 

            double? primaryValue = null;
            double? secundaryValue = null;
            

            Calculadora calc = new Calculadora();

            //Metodo que inicializa a aparencia do programa
            void StartApparence()
            {

                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
            }
            StartApparence();
            while (continuar)//O loop continua até o usuario decidir sair da aplicação
            {

                StartApparence();
                UserValueCatcher = true;
                invaSeleCont = true;
                UseOldNumDialog = true;
                secundaryValue = null;
                ckeyinfo = new ConsoleKeyInfo();

                while (invaSeleCont)//Caso seja invalido o loop continua até o usuario selecionar uma opção valida
                {

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
                            invaSeleCont = false;
                            
                            break;
                        case '+':
                            invaSeleCont = false;
                            
                            break;
                        case '-':
                            invaSeleCont = false;
                            
                            break;
                        case '/':
                            invaSeleCont = false;
                            
                            break;
                        default:
                            invaSeleCont = true;
                            Console.WriteLine("Operação invalida");
                            break;
                    }
                }


                while (UserValueCatcher)
                {

                    try
                    {
                        if (primaryValue == null)
                        {
                            Console.WriteLine("Escreva o valor primario\n" +
                           "↓");
                            primaryValue = Convert.ToDouble(Console.ReadLine());
                        }

                        Console.WriteLine("Escreva o valor secundario\n" +
                       "↓");

                        secundaryValue = Convert.ToDouble(Console.ReadLine());
                        UserValueCatcher = false;
                        Console.WriteLine($"| O valor resultante foi → [ {calc.FazerCalculo(ckeyinfo.KeyChar, Convert.ToDouble(primaryValue), Convert.ToDouble(secundaryValue))} ]  \n ");
                    }
                    catch
                    {
                        UserValueCatcher = true;
                    }
                    
                }
                        while (UseOldNumDialog)
                        {
                            
                                

                                if (calc.result != null)
                                {
                                    Console.WriteLine("" +
                                           "|Deseja usar o resultado anterior como valor primario?\n" +
                                           "   | S → Define o valor primario como o resultado atual\n" +
                                           "   | N → Limpa o resultado anterior" +
                                           "");
                                ckeyinfo = Console.ReadKey();

                                    switch (ckeyinfo.KeyChar)
                                    {
                                        case 'n':
                                        case 'N':
                                            calc.result = null;
                                            primaryValue = null;
                                            UseOldNumDialog = false;
                                            break;
                                        case 's':
                                        case 'S':
                                            primaryValue = Convert.ToDouble(calc.result);
                                            UseOldNumDialog = false;
                                            break;
                                        default:
                                            UseOldNumDialog = true;
                                            break;
                                    }
                                }
                        Console.WriteLine("" +
                               "|Deseja continuar a usar a calculadora S para sim e N para não?\n" +
                               "   | S → Você vai voltar para continuar os calculos\n" +
                               "   | N → Termina a aplicação" +
                               "");
                        ckeyinfo = Console.ReadKey();

                        switch (ckeyinfo.KeyChar)
                        {
                            case 'n':
                            case 'N':
                                continuar = false;
                                UseOldNumDialog = false;
                                break;
                            case 's':
                            case 'S':
                                continuar = true;
                                UseOldNumDialog = false;

                                break;
                            default:
                                UseOldNumDialog = true;
                                break;
                        }

                    }
                        }

                    }
                }


            }
        
    
    

            
          
          
        
