void Button1() {
    int[] n = new int[5];
    int sum = 0;

    for (int i = 0; i < 5; i++)
    {
        n[i] = int.Parse(Console.ReadLine());
        sum += n[i];
    }

    Console.WriteLine(sum);
}

void Button2() {
    int [] a = new int[100];
    int ann = 0;

    for (int l = 0; l <100; l++)
    {
        a[l] = int.Parse(Console.ReadLine());
        ann += a[l];
    }   
    Console.WriteLine(ann);
}

void Button3() {
    int sum = 0;
    for (int i = 0; i < 100; i++)
    {
        sum += i + 1;
    }
    Console.WriteLine(sum);
}

void Button4() {
    string[] a = {"a", "b", "c"};
    for (int i = 0; i < a.Length; i++)
    {
        Console.WriteLine(a[i]);
    }
    foreach (string item in a)
    {
        Console.WriteLine(item);
    }
}

void  Button5() {
    List<int> a = new List<int>() {1, 2, 3, 4, 5};

    foreach (int item in a)
    {
        Console.WriteLine(item);
    }
}

int Sum() {
    int a = 1;
    int b = 2;
    return a + b;
}

