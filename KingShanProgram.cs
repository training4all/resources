using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTreeParserProj
{
    enum Gender
    {
        FEMALE,
        MALE
    }

    class Node
    {
        int _id;
        string _name;
        Gender _sex;
        Node spouse;
        Node father;
        Node mother;
        //List<Node> siblings;
        List<Node> childern;

        static int idCounter = 0;
        public string Name { get { return _name; } }
        public Gender Sex { get { return _sex; } }
        
        public Node(string name, Gender sex)
        {
            idCounter++;
            this._id = idCounter;
            this._name = name;
            this._sex = sex;
        }

        public Node AddFather(Node father)
        {
            this.father = father;
            return this;
        }

        public Node AddMother(Node mother)
        {
            this.mother = mother;
            return this;
        }

        public Node AddSpouse(Node partner)
        {
            this.spouse = partner;
            partner.spouse = this;
            return this;
        }

        public Node AddChild(Node child)
        {
            if(this.childern == null)
              this.childern = new List<Node>();
            this.childern.Add(child);
            if (this.Sex == Gender.FEMALE)
            {
                child.AddMother(this);
                child.AddFather(this.spouse);
            }
            else
            {
                child.AddFather(this);
                child.AddMother(this.spouse);
            }

            return this;
        }

        //public Node AddSibling(Node sibling)
        //{
        //    if (this.siblings == null)
        //        this.siblings = new List<Node>();
        //    this.siblings.Add(sibling);
        //    sibling
        //    return this;
        //}
    }

    static class TreeGenerator
    {
        public static Node CreateRoot(string name, Gender sex)
        {          
            return new Node(name, sex);            
        }

        public static Node GenerateTree()
        {   
            Node root = TreeGenerator.CreateRoot("KingShan", Gender.MALE)
                                     .AddSpouse(new Node("QueenAnga", Gender.FEMALE))
                                    .AddChild(new Node("Ish", Gender.MALE))
                                    .AddChild(new Node("Chit", Gender.MALE)
                                                        .AddSpouse(new Node("Ambi", Gender.FEMALE))
                                                        .AddChild(new Node("Drita", Gender.MALE)
                                                                            .AddSpouse(new Node("Jaya", Gender.FEMALE))
                                                                            .AddChild(new Node("Jata", Gender.MALE))
                                                                            .AddChild(new Node("Driya", Gender.FEMALE)
                                                                                                .AddSpouse(new Node("Mnu", Gender.MALE))
                                                                                      )
                                                                  )
                                                        .AddChild(new Node("Vrita", Gender.MALE))
                                             )
                                    .AddChild(new Node("Vich", Gender.MALE)
                                                        .AddSpouse(new Node("Lika", Gender.FEMALE))
                                                        .AddChild(new Node("Vila", Gender.MALE)
                                                                            .AddSpouse(new Node("Jnki", Gender.FEMALE))
                                                                            .AddChild(new Node("Lavnya", Gender.FEMALE))
                                                                                                .AddSpouse(new Node("Gru", Gender.MALE))
                                                                 )
                                             )
                                    .AddChild(new Node("Satya", Gender.FEMALE)
                                                        .AddSpouse(new Node("Vyan", Gender.MALE))
                                                        .AddChild(new Node("Satvy", Gender.FEMALE)
                                                                            .AddSpouse(new Node("Asva", Gender.MALE))
                                                                 )
                                                        .AddChild(new Node("Savya", Gender.MALE)
                                                                            .AddSpouse(new Node("Krpi", Gender.FEMALE))
                                                                            .AddChild(new Node("Kriya", Gender.MALE))
                                                                 )
                                                        .AddChild(new Node("Saayan", Gender.MALE)
                                                                              .AddSpouse(new Node("Mina", Gender.FEMALE))            
                                                                              .AddChild(new Node("Misa", Gender.MALE))
                                                                  )
                                             );


            return root;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Node root = TreeGenerator.GenerateTree();            
        }
    }
}
