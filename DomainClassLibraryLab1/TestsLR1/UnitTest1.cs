namespace TestsLR1;
using System.Linq;  // ��� ��������

public class Class1Test    //���� ����� �� ����� ���� ����������� �� Object
{
    // ���������� ����� � ������
    // ����� - ������, ��������� ���� �����
    // ������ - ��������� ��������� �������� (?)
    [Fact]
    public void TestInts()
    {
        var a = 0;
        var b = 2;
        var c = a + b;
        Assert.Equal(2, c);
    }
}