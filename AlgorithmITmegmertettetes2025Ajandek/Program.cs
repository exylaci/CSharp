List<string> eredeti = new List<string>();



//Beolvasás
try
{
    foreach (var line in File.ReadLines("..\\..\\..\\ajandek.txt"))
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            Console.WriteLine("Üres sor.");
            continue;
        }
        foreach (var part in line.Split(' '))
        {
            if (part == string.Empty)
            {
                continue;
            }
            eredeti.Add(part);
            //Console.Write(part + " ");
        }
    }
    eredeti.RemoveAt(0);
    Console.WriteLine("Beolvasott adatok száma: " + eredeti.Count);
}
catch (Exception ex)
{
    Console.WriteLine($"Hiba a fájl beolvasása közben: {ex.Message}");
}



//1. feladat, piros kockák száma
int count = 0;
foreach (var item in eredeti)
{
    if (item.StartsWith('1'))
    {
        count++;
    }
}
Console.WriteLine("Piros elemek száma: " + count);



// 3D szobor felépítése lego tömbben
byte[,,] szobor = new byte[16, 16, 16]; 
int xmax = 0;
int ymax = 0;
int zmax = 0;
foreach (var item in eredeti)
{
    szobor[Convert.ToInt32(item[1].ToString(), 16),
        Convert.ToInt32(item[2].ToString(), 16),
        Convert.ToInt32(item[3].ToString(), 16)]
        = (byte)(item[0] - '0' + 1);

    zmax = Math.Max(zmax, Convert.ToInt32(item[1].ToString(), 16));
    xmax = Math.Max(xmax, Convert.ToInt32(item[2].ToString(), 16));
    ymax = Math.Max(ymax, Convert.ToInt32(item[3].ToString(), 16));
}
Console.WriteLine($"Az ajándék szobor méretei: {zmax + 1} x {xmax + 1} x {ymax + 1}");



//belső űr megszámolása
int counter = 0;
for (int x = 1; x < xmax; x++)
{
    for (int y = 1; y < ymax; y++)
    {
        for (int z = 1; z < zmax; z++)
        {
            if (szobor[z, x, y] == 0)
            {
                ++counter;
            }
        }
    }
}
Console.WriteLine($"Az üres zárvány mérete: {counter} darab 1x1x1-es elem.\n");



//A kocka 6 felszínének kirajzolása
{
    int y = 0;
    for (int z = zmax; z >= 0; --z)
    {
        for (int x = 0; x <= xmax; ++x)
        {
            EgyElemRajzolasa(szobor[z, x, y]);
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}
{
    int y = ymax;
    for (int z = zmax; z >= 0; --z)
    {
        for (int x = xmax; x >= 0; --x)
        {
            EgyElemRajzolasa(szobor[z, x, y]);
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}
{
    int x = 0;
    for (int z = zmax; z >= 0; --z)
    {
        for (int y = ymax; y >= 0; --y)
        {
            EgyElemRajzolasa(szobor[z, x, y]);
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}
{
    int x = xmax;
    for (int z = zmax; z >= 0; --z)
    {
        for (int y = 0; y <= ymax; ++y)
        {
            EgyElemRajzolasa(szobor[z, x, y]);
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}
{
    int z = zmax;
    for (int y = ymax; y >= 0; --y)
    {
        for (int x = 0; x <= xmax; ++x)
        {
            EgyElemRajzolasa(szobor[z, x, y]);
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}
{
    int z = 0;
    for (int y = 0; y < ymax; ++y)
    {
        for (int x = 0; x <= xmax; ++x)
        {
            EgyElemRajzolasa(szobor[z, x, y]);
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

static void EgyElemRajzolasa(byte elem)
{
    if (elem == 0)
    {
        Console.Write(" ");
    }
    else
    {
        Console.Write(elem);
    }
}
