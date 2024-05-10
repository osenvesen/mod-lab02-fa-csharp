  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
 public class State
{
public string Name;
public Dictionary<char, State> Transitions;
public bool IsAcceptState;
}

public class FA1
{
    State q0 = new State() { Name = "q0", IsAcceptState = false };
    State q1 = new State() { Name = "q1", IsAcceptState = false };
    State q2 = new State() { Name = "q2", IsAcceptState = true };

    State InitialState = q0;

    public FA1()
    {
        q0.Transitions = new Dictionary<char, State>()
        {
            { '0', q1 },
            { '1', q0 }
        };
        q1.Transitions = new Dictionary<char, State>()
        {
            { '0', q1 },
            { '1', q2 }
        };
        q2.Transitions = new Dictionary<char, State>()
        {
            { '0', q2 },
            { '1', q2 }
        };
    }

    public bool? Run(IEnumerable<char> s)
    {
         State current = InitialState;
            foreach (var c in s) // цикл по всем символам 
            {
                current = current.Transitions[c]; // меняем состояние на то, в которое у нас переход
                if (current == null)              // если его нет, возвращаем признак ошибки
                    return null;
                // иначе переходим к следующему
            }
            return current.IsAcceptState;         // результат true если в конце финальное состояние 
        }
    }
}
  
public class FA2
{
    State q0 = new State() { Name = "q0", IsAcceptState = false }; // четное 0, четное 1
    State q1 = new State() { Name = "q1", IsAcceptState = true };  // нечетное 0, четное 1
    State q2 = new State() { Name = "q2", IsAcceptState = true };  // четное 0, нечетное 1 
    State q3 = new State() { Name = "q3", IsAcceptState = false }; // нечетное 0, нечетное 1

    State InitialState = q0;

    public FA2()
    {
        q0.Transitions = new Dictionary<char, State>() 
        {
            { '0', q1 },
            { '1', q2 }
        };
        q1.Transitions = new Dictionary<char, State>() 
        {
            { '0', q0 },
            { '1', q3 }
        };
        q2.Transitions = new Dictionary<char, State>()
        {
            { '0', q3 },
            { '1', q0 }
        };
        q3.Transitions = new Dictionary<char, State>() 
        {
            { '0', q2 },
            { '1', q1 }
        };
    }

    public bool? Run(IEnumerable<char> s)
    {
        State current = InitialState;
            foreach (var c in s) // цикл по всем символам 
            {
                current = current.Transitions[c]; // меняем состояние на то, в которое у нас переход
                if (current == null)              // если его нет, возвращаем признак ошибки
                    return null;
                // иначе переходим к следующему
            }
            return current.IsAcceptState;         // результат true если в конце финальное состояние 
        }
    }
}

  public class FA3
{
    State q0 = new State() { Name = "q0", IsAcceptState = false };
    State q1 = new State() { Name = "q1", IsAcceptState = false };
    State q2 = new State() { Name = "q2", IsAcceptState = true };

    State InitialState = q0;

    public FA3()
    {
        q0.Transitions = new Dictionary<char, State>() 
        {
            { '0', q0 },
            { '1', q1 }
        };
        q1.Transitions = new Dictionary<char, State>() 
        {
            { '0', q0 }, 
            { '1', q2 }
        };
        q2.Transitions = new Dictionary<char, State>() 
        {
            { '0', q2 },
            { '1', q2 }
        };
    }

    public bool? Run(IEnumerable<char> s)
    {
        State current = InitialState;
            foreach (var c in s) // цикл по всем символам 
            {
                current = current.Transitions[c]; // меняем состояние на то, в которое у нас переход
                if (current == null)              // если его нет, возвращаем признак ошибки
                    return null;
                // иначе переходим к следующему
            }
            return current.IsAcceptState;         // результат true если в конце финальное состояние 
        }
    }
}

  class Program
  {
    static void Main(string[] args)
    {
      String s = "01111";
      FA1 fa1 = new FA1();
      bool? result1 = fa1.Run(s);
      Console.WriteLine(result1);
      FA2 fa2 = new FA2();
      bool? result2 = fa2.Run(s);
      Console.WriteLine(result2);
      FA3 fa3 = new FA3();
      bool? result3 = fa3.Run(s);
      Console.WriteLine(result3);
    }
  }
}
