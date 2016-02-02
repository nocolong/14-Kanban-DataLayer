using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Kanban_DataLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            char c;

            using(var db = new KanbanEntities())
            {                
                while (true)
                {
                    Console.WriteLine("Enter a command: P = Print All Lists, L= Add to List, C = Add to Card, X= Exit Program");
                    c = Console.ReadKey().KeyChar;

                    switch (c)
                    {
                        case 'X':
                            return;
                        case 'P':
                            //var list = db.Lists.First();
                            foreach (var list in db.Lists)
                            {
                                Console.WriteLine(list.Name + " " + list.ListId);

                                foreach (var card in list.Cards)
                                {

                                    Console.WriteLine("\t" + card.Text);
                                }
                            }
                            break;
                        case 'L':
                            Console.Write("Enter a list name: ");
                            string name = Console.ReadLine();
                            var lst = new List();
                            lst.Name = name;
                            lst.CreatedDate = DateTime.Now;

                            db.Lists.Add(lst);
                            db.SaveChanges();
                            break;


                        case 'C':
                            try {
                                Console.Write("Enter a card name: ");
                                string cardName = Console.ReadLine();
                                Console.Write("Enter a list Id: ");
                                int id = int.Parse(Console.ReadLine());


                                var newCard = new Card();
                                newCard.ListId = id;
                                newCard.Text = cardName;
                                newCard.CreatedDate = DateTime.Now;

                                db.Cards.Add(newCard);
                                db.SaveChanges();                                
                                

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                      }


                   

                    //Console.ReadKey();
                }
            }
        }
    }
}
