using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography;

//Bis jetzt in all getesteten Anwendungen ThreadSave

namespace exc.jdbi.Randoms
{
  /// <summary>
  /// Simple Int64/Int32 Crypto-Random
  /// Simple Opportuneness Crypto-Random
  /// </summary>
  internal sealed class SOCR
  {
    /// <summary>
    /// Stellt sicher, dass die WarmUp-Phase nur
    /// einmal beim Starten des Programmes durch-
    /// laufen wird.
    /// </summary>
    private static bool FirstWarmUp = true;

    /// <summary>
    /// RandomNumberGenerator Variable.
    /// </summary>
    [ThreadStatic]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    private static RandomNumberGenerator _Rand = RandomNumberGenerator.Create();
    private static readonly double DoubleScale = 1.0 / Convert.ToDouble(1L << 53);

    internal static bool IsAlive()
    {
      if (_Rand is null)
      {
        _Rand = RandomNumberGenerator.Create();
        WarmUp();
      }
      return true;
    }

    /// <summary>
    /// returns a value between 0 - 1
    /// </summary>
    /// <returns>Double Value</returns>
    internal static double NextDouble()
    {
      if (FirstWarmUp) WarmUp();
      int sz = sizeof(ulong);
      var b = new byte[sz];
      _Rand.GetNonZeroBytes(b);
      var scale = Convert.ToUInt64(b[0]) | Convert.ToUInt64(b[1]) << 8 | Convert.ToUInt64(b[2]) << 16 | Convert.ToUInt64(b[3]) << 24 |
                  Convert.ToUInt64(b[4]) << 32 | Convert.ToUInt64(b[5]) << 40 | Convert.ToUInt64(b[6]) << 48 | Convert.ToUInt64(b[7]) << 56;
      scale >>= 11;
      return Convert.ToDouble(scale) * DoubleScale;
    }

    internal static void NextDouble(double[] dbls)
    {
      if (FirstWarmUp) WarmUp();
      int sz = sizeof(ulong);
      var b = new byte[sz * dbls.Length];
      _Rand.GetNonZeroBytes(b);
      ulong scale;
      for (int i = 0, j = 0; i < dbls.Length; i++, j = i * sz)
      {
        scale = Convert.ToUInt64(b[j]) | Convert.ToUInt64(b[j + 1]) << 8 | Convert.ToUInt64(b[j + 2]) << 16 | Convert.ToUInt64(b[j + 3]) << 24 |
                Convert.ToUInt64(b[j + 4]) << 32 | Convert.ToUInt64(b[j + 5]) << 40 | Convert.ToUInt64(b[j + 6]) << 48 | Convert.ToUInt64(b[j + 7]) << 56;
        scale >>= 11;
        dbls[i] = Convert.ToDouble(scale) * DoubleScale;
      }
    }

    /// <summary>
    /// Fill a Array of Byte with Random-Bytes 
    /// without Zero
    /// </summary>
    /// <param name="bytes">Byte-Array</param>
    internal static void NextBytes(byte[] bytes)
    {
      if (FirstWarmUp) WarmUp();
      _Rand.GetNonZeroBytes(bytes);
    }

    /// <summary>
    /// Next Random Int32 (without Exceptions)
    /// </summary>
    /// <returns>Return a Random Int32</returns>
    internal static int Next()
    {
      // Crypto-random number of Int32
      if (FirstWarmUp) WarmUp();
      int sz = sizeof(uint);
      var b = new byte[sz];
      _Rand.GetNonZeroBytes(b);
      var scale = b[0] | (uint)(b[1] << 8) | (uint)(b[2] << 16) | (uint)(b[3] << 24);
      return ToIntsPos(scale);
    }

    /// <summary>
    /// Random Int32 in Range min - max (without Exceptions)
    /// </summary>
    /// <param name="_min">Least legal value for the Random number.</param>
    /// <param name="_max">The greatest legal return value.</param>
    /// <returns>Return a Int32 [min - max]</returns>
    internal static int Next(int _min, int _max)
    {
      // Crypto-random number of Int32 with min - max
      if (_min == _max) return _min;
      SwapCheck(ref _min, ref _max);

      if (FirstWarmUp) WarmUp();
      int sz = sizeof(uint);
      var b = new byte[sz];
      _Rand.GetNonZeroBytes(b);
      var scale = b[0] | (uint)(b[1] << 8) | (uint)(b[2] << 16) | (uint)(b[3] << 24);
      return ToIntsPos((uint)(_min + (_max - _min) * (scale / (double)uint.MaxValue)));
    }

    /// <summary>
    /// Random Int32 in Range 0 - max (without Exceptions)
    /// </summary>
    /// <param name="_max">The greatest legal return value.</param>
    /// <returns>Return a Int32 [0 - max]</returns>
    internal static int Next(int _max)
      => Next(0, _max);

    /// <summary>
    /// Fills the array with random numbers
    /// </summary>
    internal static void Next(int[] ints)
    {
      if (FirstWarmUp) WarmUp();
      int sz = sizeof(uint);
      var b = new byte[sz * ints.Length];
      _Rand.GetNonZeroBytes(b);
      for (int i = 0, j = 0; i < ints.Length; i++, j = i * sz)
        ints[i] = ToIntsPos(b[j] | (uint)(b[j + 1] << 8) | (uint)(b[j + 2] << 16) | (uint)(b[j + 3] << 24));
    }

    /// <summary>
    /// Fills the array with random numbers
    /// </summary>
    /// <param name="_min">Min Random Value</param>
    /// <param name="_max">Max Random Value</param>
    internal static void Next(int[] ints, int _min, int _max)
    {
      if (_min == _max) throw new ArgumentException("min == max");
      if (FirstWarmUp) WarmUp();

      int sz = sizeof(uint);
      SwapCheck(ref _min, ref _max);
      var b = new byte[sz * ints.Length];
      _Rand.GetNonZeroBytes(b);
      uint scale;
      for (int i = 0, j = 0; i < ints.Length; i++, j = i * sz)
      {
        scale = b[j] | (uint)(b[j + 1] << 8) | (uint)(b[j + 2] << 16) | (uint)(b[j + 3] << 24);
        ints[i] = ToIntsPos((uint)(_min + (_max - _min) * (scale / (double)uint.MaxValue)));
      }
    }

    /// <summary>
    /// Next Random Int64 (without Exceptions)
    /// </summary>
    /// <returns>Return a Random Int64</returns>
    internal static long NextI64()
    {
      // Crypto-random number of Int64
      if (FirstWarmUp) WarmUp();
      int sz = sizeof(ulong);
      var b = new byte[sz];
      _Rand.GetNonZeroBytes(b);
      var scale = Convert.ToUInt64(b[0]) | Convert.ToUInt64(b[1]) << 8 | Convert.ToUInt64(b[2]) << 16 | Convert.ToUInt64(b[3]) << 24 |
                  Convert.ToUInt64(b[4]) << 32 | Convert.ToUInt64(b[5]) << 40 | Convert.ToUInt64(b[6]) << 48 | Convert.ToUInt64(b[7]) << 56;
      return ToIntsPos(scale);
    }

    /// <summary>
    /// Random Int64 in Range min - max (without Exceptions)
    /// </summary>
    /// <param name="_min">Least legal value for the Random number.</param>
    /// <param name="_max">The greatest legal return value.</param>
    /// <returns>Return a Int64 [min - max]</returns>
    internal static long NextI64(long _min, long _max)
    {
      // Crypto-random number of Int64 with min - max
      if (_min == _max) return _min;
      SwapCheck(ref _min, ref _max);
      if (FirstWarmUp) WarmUp();
      int sz = sizeof(ulong);
      var b = new byte[sz];
      _Rand.GetNonZeroBytes(b);
      var scale = Convert.ToUInt64(b[0]) | Convert.ToUInt64(b[1]) << 8 | Convert.ToUInt64(b[2]) << 16 | Convert.ToUInt64(b[3]) << 24 |
                  Convert.ToUInt64(b[4]) << 32 | Convert.ToUInt64(b[5]) << 40 | Convert.ToUInt64(b[6]) << 48 | Convert.ToUInt64(b[7]) << 56;
      return ToIntsPos((ulong)(_min + (_max - _min) * (scale / (double)ulong.MaxValue)));
    }

    /// <summary>
    /// Random Int64 in Range 0 - max (without Exceptions)
    /// </summary>
    /// <param name="_max">The greatest legal return value.</param>
    /// <returns>Return a Int64 [0 - max]</returns>
    internal static long NextI64(long _max)
      => NextI64(0L, _max);

    /// <summary>
    /// Fills the array with random numbers
    /// </summary>
    internal static void NextI64(long[] lngs)
    {
      if (FirstWarmUp) WarmUp();
      int sz = sizeof(ulong);
      var b = new byte[sz * lngs.Length];
      _Rand.GetNonZeroBytes(b);
      for (int i = 0, j = 0; i < lngs.Length; i++, j = i * sz)
        lngs[i] = ToIntsPos(Convert.ToUInt64(b[j]) | Convert.ToUInt64(b[j + 1]) << 8 | Convert.ToUInt64(b[j + 2]) << 16 | Convert.ToUInt64(b[j + 3]) << 24 |
                  Convert.ToUInt64(b[j + 4]) << 32 | Convert.ToUInt64(b[j + 5]) << 40 | Convert.ToUInt64(b[j + 6]) << 48 | Convert.ToUInt64(b[j + 7]) << 56);
    }

    /// <summary>
    /// Fills the array with random numbers
    /// </summary>
    /// <param name="_min">Min Random Value</param>
    /// <param name="_max">Max Random Value</param>
    internal static void NextI64(long[] lngs, long _min, long _max)
    {
      if (_min == _max) throw new ArgumentException("min == max");
      if (FirstWarmUp) WarmUp();

      int sz = sizeof(ulong);
      SwapCheck(ref _min, ref _max);
      var b = new byte[sz * lngs.Length];
      _Rand.GetNonZeroBytes(b);
      ulong scale;
      for (int i = 0, j = 0; i < lngs.Length; i++, j = i * sz)
      {
        scale = Convert.ToUInt64(b[j]) | Convert.ToUInt64(b[j + 1]) << 8 | Convert.ToUInt64(b[j + 2]) << 16 | Convert.ToUInt64(b[j + 3]) << 24 |
                 Convert.ToUInt64(b[j + 4]) << 32 | Convert.ToUInt64(b[j + 5]) << 40 | Convert.ToUInt64(b[j + 6]) << 48 | Convert.ToUInt64(b[j + 7]) << 56;
        lngs[i] = ToIntsPos((ulong)(_min + (_max - _min) * (scale / (double)ulong.MaxValue)));
      }
    }

    /// <summary>
    /// Swaps two numbers if necessary
    /// </summary>
    /// <typeparam name="T">Generic Datatyp</typeparam>
    /// <param name="_min">Least legal value.</param>
    /// <param name="_max">Greater legal value.</param>
    private static void SwapCheck<T>(ref T _min, ref T _max)
      where T : IComparable<T>
    {
      // Swaps two Variable of T
      if (_min.CompareTo(_max) > 0)
      {
        T tmp; tmp = _min;
        _min = _max; _max = tmp;
      }
    }

    /// <summary>
    /// Dient der Warmphase, und kommt
    /// beim Ersten Nutzen von SOCR
    /// zum Zug.
    /// </summary>
    private static void WarmUp()
    {
      FirstWarmUp = false;
      var startcount = NextI64() % 1000;
      for (int i = 0; i < startcount; i++)
        NextI64();
    }

    private static int ToIntsPos(uint number)
      => Abs_C_Internal((int)number);

    private static long ToIntsPos(ulong number)
      => Abs_C_Internal((long)number);

    /// <summary>
    /// Stellt sicher, dass eine positive Zahl zurückgegeben wird.
    /// </summary>
    /// <param name="number">int number</param>
    /// <returns>positive int value</returns>
    private static int Abs_C_Internal(int number)
    => number == int.MinValue ? int.MaxValue : Math.Abs(number);

    /// <summary>
    /// Stellt sicher, dass eine positive Zahl zurückgegeben wird.
    /// </summary>
    /// <param name="number">long number</param>
    /// <returns>positive long value</returns>
    private static long Abs_C_Internal(long number)
    => number == long.MinValue ? long.MaxValue : Math.Abs(number);


    /// <summary>
    /// Private static CTor
    /// </summary>
    static SOCR()
   => WarmUp();
  }
}
