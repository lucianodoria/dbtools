using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Web;
using System.Text.RegularExpressions;

public static class ConvertDataTypesClass 
{
    public static bool IsDBNullValue(this object value)
	{
        try
        {
            return value == DBNull.Value ? true : false;
        }
        catch (Exception exc)
        {
            throw(exc); 
        }
	}
    public static string IsDBNullValue(this object value, string returnValue)
	{
        try
        {
            return value == DBNull.Value ? returnValue : value.ToString();
        }
        catch (Exception exc)
        {
            throw(exc); 
        }
	}
    public static string IsNullValue(this object value, string returnValue)
    {
        try
        {
            return value == null ? returnValue : value.ToString();
        }
        catch (Exception exc)
        {
            throw(exc); 
        }
    }
    public static object IsNullValueDB(this string value)
    {
        try
        {
            return string.IsNullOrEmpty(value) ? System.Data.SqlTypes.SqlString.Null : value;
        }
        catch (Exception exc)
        {
            throw(exc); 
        }
    }
    public static object IsNullValueDBAAB(this string value)
    {
        try
        {
            return string.IsNullOrEmpty(value) ? null : value;
        }
        catch (Exception exc)
        {
            throw(exc); 
        }
    }
    public static bool IsNullOrEmpty(this string value)
    {
        try
        {
            return string.IsNullOrEmpty(value) ? true : false;
        }
        catch (Exception exc)
        {
            throw(exc); 
        }
    }
    public static bool ToBoolean(this object value)
    {
        try
        {
            return Convert.ToBoolean(value);
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    public static short ToInt16(this string value)
    {
        try
        {
            return Convert.ToInt16(value);
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    public static int ToInt32(this string value)
    {
        try
        {
            return Convert.ToInt32(value);
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    public static long ToInt64(this string value)
    {
        try
        {
            return Convert.ToInt64(value);
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    public static Decimal ToDecimal(this string value)
    {
        try
        {
            return Convert.ToDecimal(value);
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    public static short ToInt16(this object value)
    {
        try
        {
            return Convert.ToInt16(value);
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    public static int ToInt32(this object value)
    {
        try
        {
            return Convert.ToInt32(value);
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    public static long ToInt64(this object value)
    {
        try
        {
            return Convert.ToInt64(value);
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    public static byte ToByte(this object value)
    {
        try
        {
            return Convert.ToByte(value);
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    public static DateTime ToDateTime(this object value)
    {
        try
        {
            return Convert.ToDateTime(value);
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    public static Decimal ToDecimal(this object value)
    {
        try
        {
            return Convert.ToDecimal(value);
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    /// <summary>
    /// Formata para texto com pontuação de milhar(1.000.000)
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToWithThousandPoint(this Int16 value)
    {
        try
        {
            return value.ToInt64().ToWithThousandPoint();
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    /// <summary>
    /// Formata para texto com pontuação de milhar(1.000.000)
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToWithThousandPoint(this Int32 value)
    {
        try
        {
            return value.ToInt64().ToWithThousandPoint();
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    /// <summary>
    /// Formata para texto com pontuação de milhar(1.000.000)
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToWithThousandPoint(this Int64 value)
    {
        try
        {
            return value <= 0 ? "0" : value.ToString("0,0", System.Globalization.CultureInfo.CreateSpecificCulture("el-GR"));
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    /// <summary>
    /// Formata para texto com pontuação de milhar(1.000.000)
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToWithThousandPoint(this object value)
    {
        try
        {
            return value.ToInt64().ToWithThousandPoint();
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    /// <summary>
    /// Formato do Odometro.(Metros/1000)
    /// </summary>
    /// <param name="value">Quantidade de metros percorridos</param>
    /// <returns>Kilometragem</returns>
    public static string ToWithThousandPoint(this string value)
    {
        try
        {
            return value.ToInt64().ToWithThousandPoint();
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }


    /// <summary>
    /// Formato do Odometro.(Metros/1000)
    /// </summary>
    /// <param name="value">Quantidade de metros percorridos</param>
    /// <returns>Kilometragem</returns>
    public static string ToOdometer(this Int32 value)
    {
        try
        {
            return value.ToInt64().ToOdometer();
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    /// <summary>
    /// Formato do Odometro.(Metros/1000)
    /// </summary>
    /// <param name="value">Quantidade de metros percorridos</param>
    /// <returns>Kilometragem</returns>
    public static string ToOdometer(this Int64 value)
    {
        long valueMeter = 0; 

        try
        {
            valueMeter = value < 1000 ? value : value / 1000;

            return valueMeter.ToWithThousandPoint();
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    /// <summary>
    /// Formato do Odometro.(Metros/1000)
    /// </summary>
    /// <param name="value">Quantidade de metros percorridos</param>
    /// <returns>Kilometragem</returns>
    public static string ToOdometer(this object value)
    {
        try
        {
            return value.ToInt64().ToOdometer();
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }
    /// <summary>
    /// Formato do Odometro.(Metros/1000)
    /// </summary>
    /// <param name="value">Quantidade de metros percorridos</param>
    /// <returns>Kilometragem</returns>
    public static string ToOdometer(this string value)
    {
        try
        {
            return value.ToInt64().ToOdometer();
        }
        catch (Exception exc)
        {
            throw (exc);
        }
    }


    /// <summary>
    /// Aplica formatação de placa (AAA-9999)
    /// </summary>
    /// <param name="value">Texto a ser formatado</param>
    /// <returns>Texto formatado</returns>
    public static string ToPlateFormat(this object value)
    {
        try
        {
            return value.ToString().ToPlateFormat(); 
        }
        catch (Exception exc)
        {
            throw(exc); 
        }
    }
    /// <summary>
    /// Aplica formatação de placa (AAA-9999)
    /// </summary>
    /// <param name="value">Texto a ser formatado</param>
    /// <returns>Texto formatado</returns>
    public static string ToPlateFormat(this string value)
    {
        try
        {
            return string.Format("{0}-{1}", value.Substring(0,3), value.Substring(3,4));
        }
        catch (Exception exc)
        {
            throw(exc); 
        }
    }
    /// <summary>
    /// Aplica formatação de dinheiro (R$ 0,0)
    /// </summary>
    /// <param name="value">Texto a ser formatado</param>
    /// <returns>Texto formatado</returns>
    public static string ToMoneyFormat(this object value)
    {
        try
        {
            return value == null ? "" : value.ToDecimal().ToMoneyFormat(); 
        }
        catch (Exception exc)
        {
            throw(exc); 
        }
    }
    /// <summary>
    /// Aplica formatação de dinheiro (R$ 0,0)
    /// </summary>
    /// <param name="value">Texto a ser formatado</param>
    /// <returns>Texto formatado</returns>
    public static string ToMoneyFormat(this decimal value)
    {
        try
        {
            return string.Format("{0:c}", value);
        }
        catch (Exception exc)
        {
            throw(exc); 
        }
    }
        /// <summary>
    /// Aplica formatação de data (dd/MM/yyyy)
    /// </summary>
    /// <param name="value">Texto a ser formatado</param>
    /// <returns>Texto formatado</returns>
    public static string ToDateFormatWithoutTime(this DateTime value)
    {
        try
        {
            return value.ToString("dd/MM/yyyy");
        }
        catch (Exception exc)
        {
            throw(exc); 
        }
    }
    /// <summary>Use this function like string.Split but instead of a character to split on, 
    /// use a maximum line width size. This is similar to a Word Wrap where no words will be split.</summary>
    /// Note if the a word is longer than the maxcharactes it will be trimmed from the start.
    /// <param name="initial">The string to parse.</param>
    /// <param name="MaxCharacters">The maximum size.</param>
    /// <remarks>This function will remove some white space at the end of a line, but allow for a blank line.</remarks>
    /// 
    /// <returns>An array of strings.</returns>
    public static List<string> SplitOn( this string initial, int MaxCharacters )
    {
 
        List<string> lines = new List<string>();
 
        if ( string.IsNullOrEmpty( initial ) == false )
        {
            string targetGroup = "Line";
            string theRegex = string.Format( @"(?<{0}>.{{1,{1}}})(?:\W|$)", targetGroup, MaxCharacters );
 
            MatchCollection matches = Regex.Matches( initial, theRegex, RegexOptions.IgnoreCase
                                                                      | RegexOptions.Multiline
                                                                      | RegexOptions.ExplicitCapture
                                                                      | RegexOptions.CultureInvariant
                                                                      | RegexOptions.Compiled );
            if ( matches != null )
                if ( matches.Count > 0 )
                    foreach ( Match m in matches )
                        lines.Add( m.Groups[targetGroup].Value );
        }
 
        return lines;
    }
    public static string GetTextMultline(this string initial, int maxCharacters )
    {
        try
        {
            string text = "";

            int countLines = initial.Length / maxCharacters;
            int countLinesRest = initial.Length % maxCharacters;
            int startIndex = 0;

            for (int i = 1; i <= countLines; i++)
            {
                text += initial.Substring(startIndex, maxCharacters) + Environment.NewLine;

                startIndex += maxCharacters - 1;
            }

            if (countLinesRest > 0)
            {
                text += initial.Substring(startIndex, countLinesRest) + Environment.NewLine;
            }

            return text;
        }
        catch
        {
            return initial;
        }
    }
    /// <summary>
    /// Converte a primeira letra para maiúscula
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string ToUpperFirstChar(this string text)
    {
        try
        {
            if (String.IsNullOrEmpty(text))
            {
                return "";
            }

            return text.First().ToString().ToUpper() + String.Join("", text.Skip(1));
        }
        catch
        {
            return text;
        }
    }
    
}
