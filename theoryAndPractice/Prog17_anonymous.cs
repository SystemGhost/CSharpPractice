using System;

/*
 * анонимная функция
 */
delegate double Function(double x);
class Test
{
    static double[] Apply(double[] a, Function f)
    {
        double[] result = new double[a.Length];
        for (int i = 0; i < a.Length; i++)
            result[i] = f(a[i]);
        return result;
    }
    static double[] MultAllBy(double[] a, double factor)
    {
        return Apply(a, delegate(double x) { return x * factor; });
    }
    static void Main()
    {
        double[] a = { 0.0, 0.5, 1.0 };
        double[] s = Apply(a, delegate(double x) { return x * x; });
        double[] doubles = MultAllBy(a, 2.0);
    }
}