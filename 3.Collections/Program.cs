using System;
using System.Collections.Generic;

void printList(List<int> l) {
    foreach (int i in l) { Console.Write($"{i} "); }
    Console.WriteLine();
}

void TestList() {
    List<int> l = new List<int>();
    l.Add(4); l.Add(3); l.Add(2); l.Add(1);
    l.Insert(2, 5);
    Console.Write("Initially filled list: ");
    printList(l);

    l.AddRange(new int[] {7, 17});
    Console.Write("Add a range of numbers: ");
    printList(l);
    
    l.Remove(3); l.RemoveAt(0); l.RemoveAll(x => x > 10);
    Console.Write("After removing some: ");
    printList(l);
    
    Console.WriteLine($"does {string.Join(", ", l)} contain {17}? {l.Contains(17)}");
    
    Console.Write("Odd numbers only: ");
    printList(l.FindAll(x => x%2 == 1));
    
    l.Sort();
    Console.Write("Sorted: ");
    printList(l);
    
    l.Reverse();
    Console.Write("Reversed: ");
    printList(l);
    
    Console.WriteLine($"Count: {l.Count}, Size: {l.Capacity}");
}


void PrintDictionary(Dictionary<string, int> d)
    {
        foreach (var p in d)
        {
            Console.Write($"({p.Key}, {p.Value}), ");
        }
        Console.WriteLine();
    }


void TestDictionary() {
        Dictionary<string, int> d = new Dictionary<string, int>
        {
            { "a", 7 },
            { "b", 17 },
            { "c", 27 }
        };

        Console.Write("initially filled dictionary: ");
        PrintDictionary(d);
        
        Console.Write("update values: ");
        foreach(var p in d) {
            d[p.Key] = p.Value + 100;
        }        
        PrintDictionary(d);

        d.Remove("c");
        Console.Write("remove c: ");
        PrintDictionary(d);

        d.Remove("c");
        Console.Write("remove c again: ");
        PrintDictionary(d);

        Console.WriteLine($"Does it contain 'c' as a key? {d.ContainsKey("c")}.");
        Console.WriteLine($"Does it contain '107' as a value? {d.ContainsValue(107)}.");
        
        if (d.TryGetValue("a", out int i)) {
            Console.WriteLine($"Successfully found a's value: {i}");
        } else {
            Console.WriteLine("a was not found in the dictionary.");
        }    
}

void PrintSet(HashSet<int> h) {
    Console.WriteLine(string.Join(", ", h));
}

void TestSet() {
    HashSet<int> h = new HashSet<int>();
    h.Add(1); h.Add(2); h.Add(3); h.Add(4); h.Add(4);
    Console.Write("add 1-4: ");
    PrintSet(h);

    // some set operations
    HashSet<int> h2 = new HashSet<int>();
    h2.Add(3); h2.Add(4); h2.Add(5); h2.Add(6);
    HashSet<int> h3 = new HashSet<int>();
    h3.Add(3); h3.Add(4); h3.Add(5); h3.Add(6);
    HashSet<int> h4 = new HashSet<int>();
    h4.Add(3); h4.Add(4); h4.Add(5); h4.Add(6);

    Console.Write("Union: ");
    h2.UnionWith(h);
    PrintSet(h2);
    Console.Write("Intersection: ");
    h3.IntersectWith(h);
    PrintSet(h3);
    Console.Write("Minus: ");
    h4.ExceptWith(h);
    PrintSet(h4);
}

Console.WriteLine("Testing methods of List...");
TestList();
Console.WriteLine("\nTesting methods of Dictionary...");
TestDictionary();
Console.WriteLine("\nTesting methods of Set...");
TestSet();