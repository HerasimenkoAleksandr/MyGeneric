using System;
using System.Collections.Generic;
using System.Collections;


namespace MyGeneric
{
    public class MySwap<T> 
    {
        public static void Swap( ref T obj1, ref T obj2)
        {
             T obj =  obj2;
             obj2 =    obj1;
            obj1 = obj;
            
        }
    };

    public class TestSwap
    {
        public string Test { get; set; }
       
        public override string ToString()
        {
            return Test;
        }
        public TestSwap(string a)
        {
           Test = a;
            
        }
    }
 
    public class MyPriorityQueue<TElement> 
    {
        public class ElementAndPriority : IComparable
        {
            public TElement StructElement;
            public int StructPriority;

            public ElementAndPriority(TElement element, int priority)
            {
                StructElement = element;
                StructPriority = priority;
            }


            public int CompareTo(object obj)
            {
                if (obj is MyPriorityQueue<TElement>.ElementAndPriority)
                {
                    return StructPriority.CompareTo((obj as MyPriorityQueue<TElement>.ElementAndPriority).StructPriority);
                }
                throw new NotImplementedException();
            }
        };
        ElementAndPriority[] Element;
        public MyPriorityQueue()
        {
            Element = new ElementAndPriority[0];
        }
        // int Priority;
        public void Add(TElement element, int priority)
        {
               
            ElementAndPriority[]  temp= new ElementAndPriority[Element.Length];
            Element.CopyTo(temp, 0);
            Array.Resize(ref Element, Element.Length + 1);
            temp.CopyTo(Element, 0);
            ElementAndPriority xc = new ElementAndPriority(element, priority);
            if (Element[Element.Length - 1] == null)
            {
                Element.SetValue(xc, Element.Length - 1);
                Console.WriteLine("В очередь c приоритетом добавлено: " + element.ToString() + " - c приоритетом ->" + priority.ToString());
            }
            else
                throw new System.ArgumentException();
               
        }
        public void Extract()
        {
            
            ElementAndPriority[] temp = Element;
            Array.Resize(ref Element, Element.Length - 1);
            Console.WriteLine("\nпроизведено извлечение элемента согласно условий структуры очереди(по max приоритету)!!!");
            Array.Sort(temp);
           Array.ConstrainedCopy(temp, 1, Element, 0, Element.Length - 1);
        }
        public void Clear()
        {
            Element = new ElementAndPriority[0];
            Console.WriteLine("\nПроизведено очистку кольцевой очереди!!!");
        }
        public void Print()
        {
            Console.WriteLine("Количество элементов " + Element.Length);
            Console.WriteLine("Демострация очереди");
            foreach (var i in Element)
            {

                //Console.WriteLine();
                Console.WriteLine("      элемент: " + i.StructElement +" (его приоритет "+i.StructPriority+")");
               
               // Console.WriteLine();
            }
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }

   public class CircularQueue<TElement>
    {
        
        TElement [] Element;
        public CircularQueue()
        {
            Element = new TElement[0];
        }
        // int Priority;
        public void Add(TElement element)
        {

            TElement[] temp = new TElement[Element.Length];
            Element.CopyTo(temp, 0);
            Array.Resize(ref Element, Element.Length + 1);
            temp.CopyTo(Element, 0);
            if (Element[Element.Length - 1] == null)
            {
                Element.SetValue(element, Element.Length - 1);
                Console.WriteLine("В кольцевую очередь добавлено: " + element.ToString());
            }
            else
                throw new System.ArgumentOutOfRangeException();

        }
        public void Extract()
        {

            TElement[] temp = Element;
            Console.WriteLine("\nпроизведено извлечение элемента согласно условий структуры очереди!!!");
            TElement element = Element[0];
            Array.ConstrainedCopy(temp, 1, Element, 0, Element.Length - 1);
            Element.SetValue(element, Element.Length - 1);
           

        }
        public void Clear()
        {
            Element = new TElement[0];
            Console.WriteLine("\nПроизведено очистку кольцевой очереди!!!");
        }
        public void Print()
        {
            Console.WriteLine("Количество элементов в очереди " + Element.Length+"\n");
            Console.Write("Демострация очереди");
            foreach (var i in Element)
            {

               // Console.WriteLine();
                Console.Write(" -->>" + i.ToString()+ "; ");
            
            }
            Console.WriteLine();
        }
    }


    public class Elements<TElement>
    {
        public Elements(TElement data)
        {
            Element = data;
        }
        public TElement Element { get; set; }
        public Elements <TElement> Next { get; set; }


    };
    public class Forward_List<TElement> 
    {
        Elements<TElement> head;
        Elements<TElement> tail;
        int count;

       

        public void Add(TElement elementP)
        {
            Elements<TElement> temp = new Elements<TElement>(elementP);
            
            if (head==null)
            {
                head=temp;
                
            }
            else
            {
                tail.Next = temp;
                tail = temp;

            }
            count++;

        }
        public void AddWithoutTail(TElement elementP)
        {
            Elements<TElement> temp = new Elements<TElement>(elementP);

            if (head == null)
            {
                head = temp;
            }
            else
            {
                Elements<TElement> current = head;

                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = temp;
            }
            count++;
            Console.WriteLine("\nДобавлено в односвязный список: " + elementP.ToString());
        }

      
        public void Remove(TElement data)
        {
            Elements<TElement> current = head;
            Elements<TElement> previous = null;
            while (current != null)
            {
                if (current.Element.Equals(data))
                {
                   if (previous != null)
                    {
                      previous.Next = current.Next;
                        if (current.Next == null)
                        tail = previous;
                    }
                    else
                    {
                       head = head.Next;
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    Console.WriteLine("Удален -->> " + data.ToString());
                    return;
                }

                previous = current;
                current = current.Next;
            }
        }

     
        public void Clear()
        {
             head=null;
             tail=null;
             count=0;
            Console.WriteLine("Произведено очистку списка!!!");
        }
        public void Print()
        {
            Console.WriteLine("\nПеребор односвязного списка! ");
            Elements<TElement> currentt = head;
            while (currentt != null)
            {
                Console.Write("-->>> " + currentt.Element);
                currentt = currentt.Next;
            }
            Console.WriteLine();
        }
        }
    public class ElementsOfList<TElement>
    {
        public ElementsOfList(TElement data)
        {
            Element = data;
        }
        public TElement Element { get; set; }
        public ElementsOfList<TElement> Next { get; set; }
        public ElementsOfList<TElement> Prev { get; set; }


    };
    public class List<TElement>
    {
        ElementsOfList<TElement> head;
        ElementsOfList<TElement> tail;
       
        int count;



      
        public void AddWithoutTail(TElement elementP)
        {
            
            ElementsOfList<TElement> temp = new ElementsOfList<TElement>(elementP);

            if (head == null)
            {
                head = temp;
            }
            else
            {
                ElementsOfList<TElement> current = head;

                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = temp;
                temp.Prev = current;
                current = temp;
                tail = temp;
            }
            count++;
            Console.WriteLine("\nДобавлено в духсвязный список: " + elementP.ToString());
        }


        public void Remove(TElement data)
        {
          
            ElementsOfList<TElement> current = head;
            ElementsOfList<TElement> previous = null;
            while (current != null)
            {
                if (current.Element.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        
                        if (current.Next == null)
                            tail = previous;
                        else
                            current.Next.Prev = previous;
                    }
                    else
                    {
                        head = head.Next;
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    Console.WriteLine("Удален -->> " + data.ToString());
                    return;
                }

                previous = current;
                current = current.Next;
            }
        }


        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
            Console.WriteLine("Произведено очистку списка!!!");
        }
        public void PrintBackward()
        {
            Console.WriteLine("\nПеребор двухсвязного списка от конца! ");
            ElementsOfList<TElement> currentt = tail;
            if (tail == null&&head!=null)
                Console.Write("-->>> " + head.Element);
             while (currentt != null)
            {
                Console.Write("-->>> " + currentt.Element);
                currentt = currentt.Prev;
            }
           
            Console.WriteLine();
        }
        public void PrintForward()
        {
            Console.WriteLine("\nПеребор двухсвязного списка от начала! ");
            ElementsOfList<TElement> currentt = head;
            while (currentt != null)
            {
                Console.Write("-->>> " + currentt.Element);
                currentt = currentt.Next;
            }
            Console.WriteLine();
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1");
            TestSwap B1 = new TestSwap("Первый обьект");
            TestSwap B2 = new TestSwap("Второй обьект");
            Console.WriteLine("Первый обьект = " + B1);
            Console.WriteLine("Втрой обьект = " + B2);
            MySwap<TestSwap>.Swap(ref B1, ref B2);
            Console.WriteLine("Отработал Swap");
            Console.WriteLine("Первый обьект = " + B1);
            Console.WriteLine("Втрой обьект = " + B2);
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Задание 2");
             MyPriorityQueue<string> TestPriorityQueue = new MyPriorityQueue<string>();
             TestPriorityQueue.Add("первый обьект", 4);
             TestPriorityQueue.Add("второй обьект", 6);
             TestPriorityQueue.Add("третий обьект", 3);
             TestPriorityQueue.Add("четвертый обьект", 1);
             TestPriorityQueue.Add("пятый обьект", 8);
             TestPriorityQueue.Print();
             TestPriorityQueue.Extract();
             TestPriorityQueue.Print();
             TestPriorityQueue.Clear();
             TestPriorityQueue.Add("второй обьект", 6);
             TestPriorityQueue.Add("третий обьект", 3);
             TestPriorityQueue.Print();
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Задание 3");

             CircularQueue<string> TestCircularQueue = new CircularQueue<string>();
                TestCircularQueue.Add("Первый обьект");
                TestCircularQueue.Add("второй обьект");
                TestCircularQueue.Add("третий обьект");
                TestCircularQueue.Add("четвертый обьект");
                TestCircularQueue.Print();
                TestCircularQueue.Extract();
                TestCircularQueue.Print();
                TestCircularQueue.Extract();
                TestCircularQueue.Print();
                TestCircularQueue.Clear();
                TestCircularQueue.Add("третий обьект");
                TestCircularQueue.Add("четвертый обьект");
                TestCircularQueue.Print();
                Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Задание 4");

             Forward_List<string> TestForward_List = new Forward_List<string>();
             TestForward_List.AddWithoutTail("Первый обьект");
             TestForward_List.AddWithoutTail("второй обьект");
             TestForward_List.AddWithoutTail("третий обьект");
             TestForward_List.AddWithoutTail("четвертый обьект");
             TestForward_List.Print();
             TestForward_List.Remove("третий обьект");
             TestForward_List.Print();
             TestForward_List.Clear();
             TestForward_List.AddWithoutTail("Первый обьект");
             TestForward_List.AddWithoutTail("второй обьект");
             TestForward_List.AddWithoutTail("третий обьект");
             TestForward_List.AddWithoutTail("четвертый обьект");
             TestForward_List.Print();

             Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Задание 5");
             List<string> TestList = new List<string>();
             TestList.AddWithoutTail("Первый обьект");
             TestList.AddWithoutTail("второй обьект");
             TestList.AddWithoutTail("третий обьект");
             TestList.AddWithoutTail("четвертый обьект");
             TestList.PrintForward();
             TestList.PrintBackward();
             TestList.Remove("третий обьект");
             TestList.PrintBackward();
             TestList.Clear();
             TestList.AddWithoutTail("третий обьект");
             TestList.AddWithoutTail("четвертый обьект");
             TestList.PrintForward();
           
        }
    }
}
