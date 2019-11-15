using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace LacViet.HPS.EDO.MVC.Common
{
    /// <summary>
    /// Lớp thực hiện việc chuẩn hóa văn bản
    /// </summary>
    public class StandardizeText
    {
        #region Properties

        public static ArrayList arrBreakChar = new ArrayList();

        #endregion

        #region Constructors

        /// <summary>
        /// Phương thức khởi tạo không tham số
        /// </summary>
        public StandardizeText()
        {
            arrBreakChar.Clear();
            arrBreakChar.Add(' ');
            arrBreakChar.Add(';');
            arrBreakChar.Add('\n');
            arrBreakChar.Add('\t');
            arrBreakChar.Add('\r');
            arrBreakChar.Add('.');
            arrBreakChar.Add(',');
            arrBreakChar.Add(';');
            arrBreakChar.Add(':');
            arrBreakChar.Add('"');
            arrBreakChar.Add('\'');
            arrBreakChar.Add('<');
            arrBreakChar.Add('>');
            arrBreakChar.Add('[');
            arrBreakChar.Add(']');
            arrBreakChar.Add('{');
            arrBreakChar.Add('}');
            arrBreakChar.Add('?');
            arrBreakChar.Add('\\');
            arrBreakChar.Add('/');
            arrBreakChar.Add('`');
            arrBreakChar.Add('~');
            arrBreakChar.Add('~');
            arrBreakChar.Add('!');
            arrBreakChar.Add('@');
            arrBreakChar.Add('#');
            arrBreakChar.Add('$');
            arrBreakChar.Add('%');
            arrBreakChar.Add('^');
            arrBreakChar.Add('&');
            arrBreakChar.Add('*');
            arrBreakChar.Add('(');
            arrBreakChar.Add(')');
            arrBreakChar.Add('-');
            arrBreakChar.Add('_');
            arrBreakChar.Add('=');
            arrBreakChar.Add('+');
            arrBreakChar.Add('|');
            arrBreakChar.Add('\0');
        }

        /// <summary>
        /// Phương thức khởi tạo có tham số
        /// </summary>
        /// <param name="breakChar">Danh sách các ký tự đặc biệt</param>
        public StandardizeText(ArrayList breakChar)
        {
            arrBreakChar = breakChar;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Chuyển về chuỗi thay thế các ký tự đặc biệt
        /// </summary>
        /// <param name="source">Chuỗi nguồn</param>
        /// <returns>Chuỗi kết quả không dấu</returns>
        public static string ToStandard(string source)
        {
            if (arrBreakChar == null || arrBreakChar.Count == 0)
            {
                var a = new StandardizeText();
            }
            bool isStop = false;
            string strReturn = "";
            strReturn = source;
            strReturn = strReturn.Trim();
            for (int i = 0; i < arrBreakChar.Count; i++)
            {
                strReturn = strReturn.Replace((char)arrBreakChar[i], ' ');
            }
            while (!isStop)
            {
                if (strReturn.Contains("  "))
                {
                    strReturn = strReturn.Replace("  ", " ");
                }
                else
                {
                    isStop = true;
                }
            }
            return strReturn;
        }

        /// <summary>
        /// Chuyển về chuỗi không dấu
        /// </summary>
        /// <param name="source">Chuỗi nguồn</param>
        /// <returns>Chuỗi kết quả</returns>
        public static string Convert2NoSign(string source)
        {
            string strReturn = source;

            #region Unicode -> TCVN 6909

            strReturn = strReturn.Replace("ắ", "a");
            strReturn = strReturn.Replace("ẳ", "a");
            strReturn = strReturn.Replace("ẵ", "a");
            strReturn = strReturn.Replace("ằ", "a");
            strReturn = strReturn.Replace("ặ", "a");
            strReturn = strReturn.Replace("ă", "a");

            strReturn = strReturn.Replace("ấ", "a");
            strReturn = strReturn.Replace("ẩ", "a");
            strReturn = strReturn.Replace("ẫ", "a");
            strReturn = strReturn.Replace("ầ", "a");
            strReturn = strReturn.Replace("ậ", "a");
            strReturn = strReturn.Replace("â", "a");

            strReturn = strReturn.Replace("á", "a");
            strReturn = strReturn.Replace("ả", "a");
            strReturn = strReturn.Replace("ã", "a");
            strReturn = strReturn.Replace("à", "a");
            strReturn = strReturn.Replace("ạ", "a");

            strReturn = strReturn.Replace("đ", "d");

            strReturn = strReturn.Replace("ế", "e");
            strReturn = strReturn.Replace("ể", "e");
            strReturn = strReturn.Replace("ễ", "e");
            strReturn = strReturn.Replace("ề", "e");
            strReturn = strReturn.Replace("ệ", "e");
            strReturn = strReturn.Replace("ê", "e");

            strReturn = strReturn.Replace("é", "e");
            strReturn = strReturn.Replace("ẻ", "e");
            strReturn = strReturn.Replace("ẽ", "e");
            strReturn = strReturn.Replace("è", "e");
            strReturn = strReturn.Replace("ẹ", "e");

            strReturn = strReturn.Replace("í", "i");
            strReturn = strReturn.Replace("ỉ", "i");
            strReturn = strReturn.Replace("ĩ", "i");
            strReturn = strReturn.Replace("ì", "i");
            strReturn = strReturn.Replace("ị", "i");

            strReturn = strReturn.Replace("ố", "o");
            strReturn = strReturn.Replace("ổ", "o");
            strReturn = strReturn.Replace("ỗ", "o");
            strReturn = strReturn.Replace("ồ", "o");
            strReturn = strReturn.Replace("ộ", "o");
            strReturn = strReturn.Replace("ô", "o");

            strReturn = strReturn.Replace("ớ", "o");
            strReturn = strReturn.Replace("ở", "o");
            strReturn = strReturn.Replace("ỡ", "o");
            strReturn = strReturn.Replace("ờ", "o");
            strReturn = strReturn.Replace("ợ", "o");
            strReturn = strReturn.Replace("ơ", "o");

            strReturn = strReturn.Replace("ó", "o");
            strReturn = strReturn.Replace("ỏ", "o");
            strReturn = strReturn.Replace("õ", "o");
            strReturn = strReturn.Replace("ò", "o");
            strReturn = strReturn.Replace("ọ", "o");

            strReturn = strReturn.Replace("ứ", "u");
            strReturn = strReturn.Replace("ử", "u");
            strReturn = strReturn.Replace("ữ", "u");
            strReturn = strReturn.Replace("ừ", "u");
            strReturn = strReturn.Replace("ự", "u");
            strReturn = strReturn.Replace("ư", "u");

            strReturn = strReturn.Replace("ú", "u");
            strReturn = strReturn.Replace("ủ", "u");
            strReturn = strReturn.Replace("ũ", "u");
            strReturn = strReturn.Replace("ù", "u");
            strReturn = strReturn.Replace("ụ", "u");

            strReturn = strReturn.Replace("ý", "y");
            strReturn = strReturn.Replace("ỷ", "y");
            strReturn = strReturn.Replace("ỹ", "y");
            strReturn = strReturn.Replace("ỳ", "y");
            strReturn = strReturn.Replace("ỵ", "y");

            strReturn = strReturn.Replace("Ắ", "A");
            strReturn = strReturn.Replace("Ẳ", "A");
            strReturn = strReturn.Replace("Ẵ", "A");
            strReturn = strReturn.Replace("Ằ", "A");
            strReturn = strReturn.Replace("Ặ", "A");
            strReturn = strReturn.Replace("Ă", "A");

            strReturn = strReturn.Replace("Ấ", "A");
            strReturn = strReturn.Replace("Ẩ", "A");
            strReturn = strReturn.Replace("Ẫ", "A");
            strReturn = strReturn.Replace("Ầ", "A");
            strReturn = strReturn.Replace("Ậ", "A");
            strReturn = strReturn.Replace("Â", "A");

            strReturn = strReturn.Replace("Á", "A");
            strReturn = strReturn.Replace("Ả", "A");
            strReturn = strReturn.Replace("Ã", "A");
            strReturn = strReturn.Replace("À", "A");
            strReturn = strReturn.Replace("Ạ", "A");

            strReturn = strReturn.Replace("Đ", "D");

            strReturn = strReturn.Replace("Ế", "E");
            strReturn = strReturn.Replace("Ể", "E");
            strReturn = strReturn.Replace("Ễ", "E");
            strReturn = strReturn.Replace("Ề", "E");
            strReturn = strReturn.Replace("Ệ", "E");
            strReturn = strReturn.Replace("Ê", "E");

            strReturn = strReturn.Replace("É", "E");
            strReturn = strReturn.Replace("Ẻ", "E");
            strReturn = strReturn.Replace("Ẽ", "E");
            strReturn = strReturn.Replace("È", "E");
            strReturn = strReturn.Replace("Ẹ", "E");

            strReturn = strReturn.Replace("Í", "I");
            strReturn = strReturn.Replace("Ỉ", "I");
            strReturn = strReturn.Replace("Ĩ", "I");
            strReturn = strReturn.Replace("Ì", "I");
            strReturn = strReturn.Replace("Ị", "I");

            strReturn = strReturn.Replace("Ố", "O");
            strReturn = strReturn.Replace("Ổ", "O");
            strReturn = strReturn.Replace("Ỗ", "O");
            strReturn = strReturn.Replace("Ồ", "O");
            strReturn = strReturn.Replace("Ộ", "O");
            strReturn = strReturn.Replace("Ô", "O");

            strReturn = strReturn.Replace("Ớ", "O");
            strReturn = strReturn.Replace("Ở", "O");
            strReturn = strReturn.Replace("Ỡ", "O");
            strReturn = strReturn.Replace("Ờ", "O");
            strReturn = strReturn.Replace("Ợ", "O");
            strReturn = strReturn.Replace("Ơ", "O");

            strReturn = strReturn.Replace("Ó", "O");
            strReturn = strReturn.Replace("Ỏ", "O");
            strReturn = strReturn.Replace("Õ", "O");
            strReturn = strReturn.Replace("Ò", "O");
            strReturn = strReturn.Replace("Ọ", "O");

            strReturn = strReturn.Replace("Ứ", "U");
            strReturn = strReturn.Replace("Ử", "U");
            strReturn = strReturn.Replace("Ữ", "U");
            strReturn = strReturn.Replace("Ừ", "U");
            strReturn = strReturn.Replace("Ự", "U");
            strReturn = strReturn.Replace("Ư", "U");

            strReturn = strReturn.Replace("Ú", "U");
            strReturn = strReturn.Replace("Ủ", "U");
            strReturn = strReturn.Replace("Ũ", "U");
            strReturn = strReturn.Replace("Ù", "U");
            strReturn = strReturn.Replace("Ụ", "U");

            strReturn = strReturn.Replace("Ý", "Y");
            strReturn = strReturn.Replace("Ỷ", "Y");
            strReturn = strReturn.Replace("Ỹ", "Y");
            strReturn = strReturn.Replace("Ỳ", "Y");
            strReturn = strReturn.Replace("Ỵ", "Y");

            #endregion

            #region Unicode tổ hợp -> Unicode Vietnamese

            strReturn = strReturn.Replace("ắ", "a");
            strReturn = strReturn.Replace("ẳ", "a");
            strReturn = strReturn.Replace("ẵ", "a");
            strReturn = strReturn.Replace("ằ", "a");
            strReturn = strReturn.Replace("ặ", "a");
            strReturn = strReturn.Replace("ă", "a");

            strReturn = strReturn.Replace("ấ", "a");
            strReturn = strReturn.Replace("ẩ", "a");
            strReturn = strReturn.Replace("ẫ", "a");
            strReturn = strReturn.Replace("ầ", "a");
            strReturn = strReturn.Replace("ậ", "a");
            strReturn = strReturn.Replace("â", "a");

            strReturn = strReturn.Replace("á", "a");
            strReturn = strReturn.Replace("ả", "a");
            strReturn = strReturn.Replace("ã", "a");
            strReturn = strReturn.Replace("à", "a");
            strReturn = strReturn.Replace("ạ", "a");

            strReturn = strReturn.Replace("đ", "d");

            strReturn = strReturn.Replace("ế", "e");
            strReturn = strReturn.Replace("ể", "e");
            strReturn = strReturn.Replace("ễ", "e");
            strReturn = strReturn.Replace("ề", "e");
            strReturn = strReturn.Replace("ệ", "e");
            strReturn = strReturn.Replace("ê", "e");

            strReturn = strReturn.Replace("é", "e");
            strReturn = strReturn.Replace("ẻ", "e");
            strReturn = strReturn.Replace("ẽ", "e");
            strReturn = strReturn.Replace("è", "e");
            strReturn = strReturn.Replace("ẹ", "e");

            strReturn = strReturn.Replace("í", "i");
            strReturn = strReturn.Replace("ỉ", "i");
            strReturn = strReturn.Replace("ĩ", "i");
            strReturn = strReturn.Replace("ì", "i");
            strReturn = strReturn.Replace("ị", "i");

            strReturn = strReturn.Replace("ố", "o");
            strReturn = strReturn.Replace("ổ", "o");
            strReturn = strReturn.Replace("ỗ", "o");
            strReturn = strReturn.Replace("ồ", "o");
            strReturn = strReturn.Replace("ộ", "o");
            strReturn = strReturn.Replace("ô", "o");

            strReturn = strReturn.Replace("ớ", "o");
            strReturn = strReturn.Replace("ở", "o");
            strReturn = strReturn.Replace("ỡ", "o");
            strReturn = strReturn.Replace("ờ", "o");
            strReturn = strReturn.Replace("ợ", "o");
            strReturn = strReturn.Replace("ơ", "o");

            strReturn = strReturn.Replace("ó", "o");
            strReturn = strReturn.Replace("ỏ", "o");
            strReturn = strReturn.Replace("õ", "o");
            strReturn = strReturn.Replace("ò", "o");
            strReturn = strReturn.Replace("ọ", "o");

            strReturn = strReturn.Replace("ứ", "u");
            strReturn = strReturn.Replace("ử", "u");
            strReturn = strReturn.Replace("ữ", "u");
            strReturn = strReturn.Replace("ừ", "u");
            strReturn = strReturn.Replace("ự", "u");
            strReturn = strReturn.Replace("ư", "u");

            strReturn = strReturn.Replace("ú", "u");
            strReturn = strReturn.Replace("ủ", "u");
            strReturn = strReturn.Replace("ũ", "u");
            strReturn = strReturn.Replace("ù", "u");
            strReturn = strReturn.Replace("ụ", "u");

            strReturn = strReturn.Replace("ý", "y");
            strReturn = strReturn.Replace("ỷ", "y");
            strReturn = strReturn.Replace("ỹ", "y");
            strReturn = strReturn.Replace("ỳ", "y");
            strReturn = strReturn.Replace("ỵ", "y");

            strReturn = strReturn.Replace("Ắ", "A");
            strReturn = strReturn.Replace("Ẳ", "A");
            strReturn = strReturn.Replace("Ẵ", "A");
            strReturn = strReturn.Replace("Ằ", "A");
            strReturn = strReturn.Replace("Ặ", "A");
            strReturn = strReturn.Replace("Ă", "A");

            strReturn = strReturn.Replace("Ấ", "A");
            strReturn = strReturn.Replace("Ẩ", "A");
            strReturn = strReturn.Replace("Ẫ", "A");
            strReturn = strReturn.Replace("Ầ", "A");
            strReturn = strReturn.Replace("Ậ", "A");
            strReturn = strReturn.Replace("Â", "A");

            strReturn = strReturn.Replace("Á", "A");
            strReturn = strReturn.Replace("Ả", "A");
            strReturn = strReturn.Replace("Ã", "A");
            strReturn = strReturn.Replace("À", "A");
            strReturn = strReturn.Replace("Ạ", "A");

            strReturn = strReturn.Replace("Đ", "D");

            strReturn = strReturn.Replace("Ế", "E");
            strReturn = strReturn.Replace("Ể", "E");
            strReturn = strReturn.Replace("Ễ", "E");
            strReturn = strReturn.Replace("Ề", "E");
            strReturn = strReturn.Replace("Ệ", "E");
            strReturn = strReturn.Replace("Ê", "E");

            strReturn = strReturn.Replace("É", "E");
            strReturn = strReturn.Replace("Ẻ", "E");
            strReturn = strReturn.Replace("Ẽ", "E");
            strReturn = strReturn.Replace("È", "E");
            strReturn = strReturn.Replace("Ẹ", "E");

            strReturn = strReturn.Replace("Í", "I");
            strReturn = strReturn.Replace("Ỉ", "I");
            strReturn = strReturn.Replace("Ĩ", "I");
            strReturn = strReturn.Replace("Ì", "I");
            strReturn = strReturn.Replace("Ị", "I");

            strReturn = strReturn.Replace("Ố", "O");
            strReturn = strReturn.Replace("Ổ", "O");
            strReturn = strReturn.Replace("Ỗ", "O");
            strReturn = strReturn.Replace("Ồ", "O");
            strReturn = strReturn.Replace("Ộ", "O");
            strReturn = strReturn.Replace("Ô", "O");

            strReturn = strReturn.Replace("Ớ", "O");
            strReturn = strReturn.Replace("Ở", "O");
            strReturn = strReturn.Replace("Ỡ", "O");
            strReturn = strReturn.Replace("Ờ", "O");
            strReturn = strReturn.Replace("Ợ", "O");
            strReturn = strReturn.Replace("Ơ", "O");

            strReturn = strReturn.Replace("Ó", "O");
            strReturn = strReturn.Replace("Ỏ", "O");
            strReturn = strReturn.Replace("Õ", "O");
            strReturn = strReturn.Replace("Ò", "O");
            strReturn = strReturn.Replace("Ọ", "O");

            strReturn = strReturn.Replace("Ứ", "U");
            strReturn = strReturn.Replace("Ử", "U");
            strReturn = strReturn.Replace("Ữ", "U");
            strReturn = strReturn.Replace("Ừ", "U");
            strReturn = strReturn.Replace("Ự", "U");
            strReturn = strReturn.Replace("Ư", "U");

            strReturn = strReturn.Replace("Ú", "U");
            strReturn = strReturn.Replace("Ủ", "U");
            strReturn = strReturn.Replace("Ũ", "U");
            strReturn = strReturn.Replace("Ù", "U");
            strReturn = strReturn.Replace("Ụ", "U");

            strReturn = strReturn.Replace("Ý", "Y");
            strReturn = strReturn.Replace("Ỷ", "Y");
            strReturn = strReturn.Replace("Ỹ", "Y");
            strReturn = strReturn.Replace("Ỳ", "Y");
            strReturn = strReturn.Replace("Ỵ", "Y");

            #endregion

            return strReturn;
        }

        /// <summary>
        /// Chuyển về chuỗi Unicode
        /// </summary>
        /// <param name="source">Chuỗi nguồn</param>
        /// <returns>Chuỗi kết quả</returns>
        public static string Convert2StandardUnicode(string source)
        {
            string strReturn = source;

            #region TCVN 6909 -> Unicode Vietnamese

            strReturn = strReturn.Replace("ắ", "ắ");
            strReturn = strReturn.Replace("ẳ", "ẳ");
            strReturn = strReturn.Replace("ẵ", "ẵ");
            strReturn = strReturn.Replace("ằ", "ằ");
            strReturn = strReturn.Replace("ặ", "ặ");
            strReturn = strReturn.Replace("ă", "ă");

            strReturn = strReturn.Replace("ấ", "ấ");
            strReturn = strReturn.Replace("ẩ", "ẩ");
            strReturn = strReturn.Replace("ẫ", "ẫ");
            strReturn = strReturn.Replace("ầ", "ầ");
            strReturn = strReturn.Replace("ậ", "ậ");
            strReturn = strReturn.Replace("â", "â");

            strReturn = strReturn.Replace("á", "á");
            strReturn = strReturn.Replace("ả", "ả");
            strReturn = strReturn.Replace("ã", "ã");
            strReturn = strReturn.Replace("à", "à");
            strReturn = strReturn.Replace("ạ", "ạ");

            strReturn = strReturn.Replace("đ", "đ");

            strReturn = strReturn.Replace("ế", "ế");
            strReturn = strReturn.Replace("ể", "ể");
            strReturn = strReturn.Replace("ễ", "ễ");
            strReturn = strReturn.Replace("ề", "ề");
            strReturn = strReturn.Replace("ệ", "ệ");
            strReturn = strReturn.Replace("ê", "ê");

            strReturn = strReturn.Replace("é", "é");
            strReturn = strReturn.Replace("ẻ", "ẻ");
            strReturn = strReturn.Replace("ẽ", "ẽ");
            strReturn = strReturn.Replace("è", "è");
            strReturn = strReturn.Replace("ẹ", "ẹ");

            strReturn = strReturn.Replace("í", "í");
            strReturn = strReturn.Replace("ỉ", "ỉ");
            strReturn = strReturn.Replace("ĩ", "ĩ");
            strReturn = strReturn.Replace("ì", "ì");
            strReturn = strReturn.Replace("ị", "ị");

            strReturn = strReturn.Replace("ố", "ố");
            strReturn = strReturn.Replace("ổ", "ổ");
            strReturn = strReturn.Replace("ỗ", "ỗ");
            strReturn = strReturn.Replace("ồ", "ồ");
            strReturn = strReturn.Replace("ộ", "ộ");
            strReturn = strReturn.Replace("ô", "ô");

            strReturn = strReturn.Replace("ớ", "ớ");
            strReturn = strReturn.Replace("ở", "ở");
            strReturn = strReturn.Replace("ỡ", "ỡ");
            strReturn = strReturn.Replace("ờ", "ờ");
            strReturn = strReturn.Replace("ợ", "ợ");
            strReturn = strReturn.Replace("ơ", "ơ");

            strReturn = strReturn.Replace("ó", "ó");
            strReturn = strReturn.Replace("ỏ", "ỏ");
            strReturn = strReturn.Replace("õ", "õ");
            strReturn = strReturn.Replace("ò", "ò");
            strReturn = strReturn.Replace("ọ", "ọ");

            strReturn = strReturn.Replace("ứ", "ứ");
            strReturn = strReturn.Replace("ử", "ử");
            strReturn = strReturn.Replace("ữ", "ữ");
            strReturn = strReturn.Replace("ừ", "ừ");
            strReturn = strReturn.Replace("ự", "ự");
            strReturn = strReturn.Replace("ư", "ư");

            strReturn = strReturn.Replace("ú", "ú");
            strReturn = strReturn.Replace("ủ", "ủ");
            strReturn = strReturn.Replace("ũ", "ũ");
            strReturn = strReturn.Replace("ù", "ù");
            strReturn = strReturn.Replace("ụ", "ụ");

            strReturn = strReturn.Replace("ý", "ý");
            strReturn = strReturn.Replace("ỷ", "ỷ");
            strReturn = strReturn.Replace("ỹ", "ỹ");
            strReturn = strReturn.Replace("ỳ", "ỳ");
            strReturn = strReturn.Replace("ỵ", "ỵ");

            strReturn = strReturn.Replace("Ắ", "Ắ");
            strReturn = strReturn.Replace("Ẳ", "Ẳ");
            strReturn = strReturn.Replace("Ẵ", "Ẵ");
            strReturn = strReturn.Replace("Ằ", "Ằ");
            strReturn = strReturn.Replace("Ặ", "Ặ");
            strReturn = strReturn.Replace("Ă", "Ă");

            strReturn = strReturn.Replace("Ấ", "Ấ");
            strReturn = strReturn.Replace("Ẩ", "Ẩ");
            strReturn = strReturn.Replace("Ẫ", "Ẫ");
            strReturn = strReturn.Replace("Ầ", "Ầ");
            strReturn = strReturn.Replace("Ậ", "Ậ");
            strReturn = strReturn.Replace("Â", "Â");

            strReturn = strReturn.Replace("Á", "Á");
            strReturn = strReturn.Replace("Ả", "Ả");
            strReturn = strReturn.Replace("Ã", "Ã");
            strReturn = strReturn.Replace("À", "À");
            strReturn = strReturn.Replace("Ạ", "Ạ");

            strReturn = strReturn.Replace("Đ", "Đ");

            strReturn = strReturn.Replace("Ế", "Ế");
            strReturn = strReturn.Replace("Ể", "Ể");
            strReturn = strReturn.Replace("Ễ", "Ễ");
            strReturn = strReturn.Replace("Ề", "Ề");
            strReturn = strReturn.Replace("Ệ", "Ệ");
            strReturn = strReturn.Replace("Ê", "Ê");

            strReturn = strReturn.Replace("É", "É");
            strReturn = strReturn.Replace("Ẻ", "Ẻ");
            strReturn = strReturn.Replace("Ẽ", "Ẽ");
            strReturn = strReturn.Replace("È", "È");
            strReturn = strReturn.Replace("Ẹ", "Ẹ");

            strReturn = strReturn.Replace("Í", "Í");
            strReturn = strReturn.Replace("Ỉ", "Ỉ");
            strReturn = strReturn.Replace("Ĩ", "Ĩ");
            strReturn = strReturn.Replace("Ì", "Ì");
            strReturn = strReturn.Replace("Ị", "Ị");

            strReturn = strReturn.Replace("Ố", "Ố");
            strReturn = strReturn.Replace("Ổ", "Ổ");
            strReturn = strReturn.Replace("Ỗ", "Ỗ");
            strReturn = strReturn.Replace("Ồ", "Ồ");
            strReturn = strReturn.Replace("Ộ", "Ộ");
            strReturn = strReturn.Replace("Ô", "Ô");

            strReturn = strReturn.Replace("Ớ", "Ớ");
            strReturn = strReturn.Replace("Ở", "Ở");
            strReturn = strReturn.Replace("Ỡ", "Ỡ");
            strReturn = strReturn.Replace("Ờ", "Ờ");
            strReturn = strReturn.Replace("Ợ", "Ợ");
            strReturn = strReturn.Replace("Ơ", "Ơ");

            strReturn = strReturn.Replace("Ó", "Ó");
            strReturn = strReturn.Replace("Ỏ", "Ỏ");
            strReturn = strReturn.Replace("Õ", "Õ");
            strReturn = strReturn.Replace("Ò", "Ò");
            strReturn = strReturn.Replace("Ọ", "Ọ");

            strReturn = strReturn.Replace("Ứ", "Ứ");
            strReturn = strReturn.Replace("Ử", "Ử");
            strReturn = strReturn.Replace("Ữ", "Ữ");
            strReturn = strReturn.Replace("Ừ", "Ừ");
            strReturn = strReturn.Replace("Ự", "Ự");
            strReturn = strReturn.Replace("Ư", "Ư");

            strReturn = strReturn.Replace("Ú", "Ú");
            strReturn = strReturn.Replace("Ủ", "Ủ");
            strReturn = strReturn.Replace("Ũ", "Ũ");
            strReturn = strReturn.Replace("Ù", "Ù");
            strReturn = strReturn.Replace("Ụ", "Ụ");

            strReturn = strReturn.Replace("Ý", "Ý");
            strReturn = strReturn.Replace("Ỷ", "Ỷ");
            strReturn = strReturn.Replace("Ỹ", "Ỹ");
            strReturn = strReturn.Replace("Ỳ", "Ỳ");
            strReturn = strReturn.Replace("Ỵ", "Ỵ");

            #endregion

            #region TCVN3 (ABC) -> Unicode Vietnamese

            strReturn = strReturn.Replace("¾", "ắ");
            strReturn = strReturn.Replace("¼", "ẳ");
            strReturn = strReturn.Replace("½", "ẵ");
            strReturn = strReturn.Replace("»", "ằ");
            strReturn = strReturn.Replace("Æ", "ặ");
            strReturn = strReturn.Replace("¨", "ă");

            strReturn = strReturn.Replace("Ê", "ấ");
            strReturn = strReturn.Replace("È", "ẩ");
            strReturn = strReturn.Replace("É", "ẫ");
            strReturn = strReturn.Replace("Ç", "ầ");
            strReturn = strReturn.Replace("Ë", "ậ");
            strReturn = strReturn.Replace("©", "â");

            strReturn = strReturn.Replace("¸", "á");
            strReturn = strReturn.Replace("¶", "ả");
            strReturn = strReturn.Replace("·", "ã");
            strReturn = strReturn.Replace("µ", "à");
            strReturn = strReturn.Replace("¹", "ạ");

            strReturn = strReturn.Replace("®", "đ");

            strReturn = strReturn.Replace("Õ", "ế");
            strReturn = strReturn.Replace("Ó", "ể");
            strReturn = strReturn.Replace("Ô", "ễ");
            strReturn = strReturn.Replace("Ò", "ề");
            strReturn = strReturn.Replace("Ö", "ệ");
            strReturn = strReturn.Replace("ª", "ê");

            strReturn = strReturn.Replace("Ð", "é");
            strReturn = strReturn.Replace("Î", "ẻ");
            strReturn = strReturn.Replace("Ï", "ẽ");
            strReturn = strReturn.Replace("Ì", "è");
            strReturn = strReturn.Replace("Ñ", "ẹ");

            strReturn = strReturn.Replace("Ý", "í");
            strReturn = strReturn.Replace("Ø", "ỉ");
            strReturn = strReturn.Replace("Ü", "ĩ");
            strReturn = strReturn.Replace("×", "ì");
            strReturn = strReturn.Replace("Þ", "ị");

            strReturn = strReturn.Replace("è", "ố");
            strReturn = strReturn.Replace("æ", "ổ");
            strReturn = strReturn.Replace("ç", "ỗ");
            strReturn = strReturn.Replace("å", "ồ");
            strReturn = strReturn.Replace("é", "ộ");
            strReturn = strReturn.Replace("«", "ô");

            strReturn = strReturn.Replace("í", "ớ");
            strReturn = strReturn.Replace("ë", "ở");
            strReturn = strReturn.Replace("ì", "ỡ");
            strReturn = strReturn.Replace("ê", "ờ");
            strReturn = strReturn.Replace("î", "ợ");
            strReturn = strReturn.Replace("¬", "ơ");

            strReturn = strReturn.Replace("ã", "ó");
            strReturn = strReturn.Replace("á", "ỏ");
            strReturn = strReturn.Replace("â", "õ");
            strReturn = strReturn.Replace("ß", "ò");
            strReturn = strReturn.Replace("ä", "ọ");

            strReturn = strReturn.Replace("ø", "ứ");
            strReturn = strReturn.Replace("ö", "ử");
            strReturn = strReturn.Replace("÷", "ữ");
            strReturn = strReturn.Replace("õ", "ừ");
            strReturn = strReturn.Replace("ù", "ự");
            strReturn = strReturn.Replace("­", "ư");

            strReturn = strReturn.Replace("ó", "ú");
            strReturn = strReturn.Replace("ñ", "ủ");
            strReturn = strReturn.Replace("ò", "ũ");
            strReturn = strReturn.Replace("ï", "ù");
            strReturn = strReturn.Replace("ô", "ụ");

            strReturn = strReturn.Replace("ý", "ý");
            strReturn = strReturn.Replace("û", "ỷ");
            strReturn = strReturn.Replace("ü", "ỹ");
            strReturn = strReturn.Replace("ú", "ỳ");
            strReturn = strReturn.Replace("þ", "ỵ");

            strReturn = strReturn.Replace("¾", "Ắ");
            strReturn = strReturn.Replace("¼", "Ẳ");
            strReturn = strReturn.Replace("½", "Ẵ");
            strReturn = strReturn.Replace("»", "Ằ");
            strReturn = strReturn.Replace("Æ", "Ặ");
            strReturn = strReturn.Replace("¡", "Ă");

            strReturn = strReturn.Replace("Ê", "Ấ");
            strReturn = strReturn.Replace("È", "Ẩ");
            strReturn = strReturn.Replace("É", "Ẫ");
            strReturn = strReturn.Replace("Ç", "Ầ");
            strReturn = strReturn.Replace("Ë", "Ậ");
            strReturn = strReturn.Replace("¢", "Â");

            strReturn = strReturn.Replace("¸", "Á");
            strReturn = strReturn.Replace("¶", "Ả");
            strReturn = strReturn.Replace("·", "Ã");
            strReturn = strReturn.Replace("µ", "À");
            strReturn = strReturn.Replace("¹", "Ạ");

            strReturn = strReturn.Replace("§", "Đ");

            strReturn = strReturn.Replace("Õ", "Ế");
            strReturn = strReturn.Replace("Ó", "Ể");
            strReturn = strReturn.Replace("Ô", "Ễ");
            strReturn = strReturn.Replace("Ò", "Ề");
            strReturn = strReturn.Replace("Ö", "Ệ");
            strReturn = strReturn.Replace("£", "Ê");

            strReturn = strReturn.Replace("Ð", "É");
            strReturn = strReturn.Replace("Î", "Ẻ");
            strReturn = strReturn.Replace("Ï", "Ẽ");
            strReturn = strReturn.Replace("Ì", "È");
            strReturn = strReturn.Replace("Ñ", "Ẹ");

            strReturn = strReturn.Replace("Ý", "Í");
            strReturn = strReturn.Replace("Ø", "Ỉ");
            strReturn = strReturn.Replace("Ü", "Ĩ");
            strReturn = strReturn.Replace("×", "Ì");
            strReturn = strReturn.Replace("Þ", "Ị");

            strReturn = strReturn.Replace("è", "Ố");
            strReturn = strReturn.Replace("æ", "Ổ");
            strReturn = strReturn.Replace("ç", "Ỗ");
            strReturn = strReturn.Replace("å", "Ồ");
            strReturn = strReturn.Replace("é", "Ộ");
            strReturn = strReturn.Replace("¤", "Ô");

            strReturn = strReturn.Replace("í", "Ớ");
            strReturn = strReturn.Replace("ë", "Ở");
            strReturn = strReturn.Replace("ì", "Ỡ");
            strReturn = strReturn.Replace("ê", "Ờ");
            strReturn = strReturn.Replace("î", "Ợ");
            strReturn = strReturn.Replace("¥", "Ơ");

            strReturn = strReturn.Replace("ã", "Ó");
            strReturn = strReturn.Replace("á", "Ỏ");
            strReturn = strReturn.Replace("â", "Õ");
            strReturn = strReturn.Replace("ß", "Ò");
            strReturn = strReturn.Replace("ä", "Ọ");

            strReturn = strReturn.Replace("ø", "Ứ");
            strReturn = strReturn.Replace("ö", "Ử");
            strReturn = strReturn.Replace("÷", "Ữ");
            strReturn = strReturn.Replace("õ", "Ừ");
            strReturn = strReturn.Replace("ù", "Ự");
            strReturn = strReturn.Replace("¦", "Ư");

            strReturn = strReturn.Replace("ó", "Ú");
            strReturn = strReturn.Replace("ñ", "Ủ");
            strReturn = strReturn.Replace("ò", "Ũ");
            strReturn = strReturn.Replace("ï", "Ù");
            strReturn = strReturn.Replace("ô", "Ụ");

            strReturn = strReturn.Replace("ý", "Ý");
            strReturn = strReturn.Replace("û", "Ỷ");
            strReturn = strReturn.Replace("ü", "Ỹ");
            strReturn = strReturn.Replace("ú", "Ỳ");
            strReturn = strReturn.Replace("þ", "Ỵ");

            #endregion

            #region Unicode tổ hợp -> Unicode Vietnamese

            strReturn = strReturn.Replace("ắ", "ắ");
            strReturn = strReturn.Replace("ẳ", "ẳ");
            strReturn = strReturn.Replace("ẵ", "ẵ");
            strReturn = strReturn.Replace("ằ", "ằ");
            strReturn = strReturn.Replace("ặ", "ặ");
            strReturn = strReturn.Replace("ă", "ă");

            strReturn = strReturn.Replace("ấ", "ấ");
            strReturn = strReturn.Replace("ẩ", "ẩ");
            strReturn = strReturn.Replace("ẫ", "ẫ");
            strReturn = strReturn.Replace("ầ", "ầ");
            strReturn = strReturn.Replace("ậ", "ậ");
            strReturn = strReturn.Replace("â", "â");

            strReturn = strReturn.Replace("á", "á");
            strReturn = strReturn.Replace("ả", "ả");
            strReturn = strReturn.Replace("ã", "ã");
            strReturn = strReturn.Replace("à", "à");
            strReturn = strReturn.Replace("ạ", "ạ");

            strReturn = strReturn.Replace("đ", "đ");

            strReturn = strReturn.Replace("ế", "ế");
            strReturn = strReturn.Replace("ể", "ể");
            strReturn = strReturn.Replace("ễ", "ễ");
            strReturn = strReturn.Replace("ề", "ề");
            strReturn = strReturn.Replace("ệ", "ệ");
            strReturn = strReturn.Replace("ê", "ê");

            strReturn = strReturn.Replace("é", "é");
            strReturn = strReturn.Replace("ẻ", "ẻ");
            strReturn = strReturn.Replace("ẽ", "ẽ");
            strReturn = strReturn.Replace("è", "è");
            strReturn = strReturn.Replace("ẹ", "ẹ");

            strReturn = strReturn.Replace("í", "í");
            strReturn = strReturn.Replace("ỉ", "ỉ");
            strReturn = strReturn.Replace("ĩ", "ĩ");
            strReturn = strReturn.Replace("ì", "ì");
            strReturn = strReturn.Replace("ị", "ị");

            strReturn = strReturn.Replace("ố", "ố");
            strReturn = strReturn.Replace("ổ", "ổ");
            strReturn = strReturn.Replace("ỗ", "ỗ");
            strReturn = strReturn.Replace("ồ", "ồ");
            strReturn = strReturn.Replace("ộ", "ộ");
            strReturn = strReturn.Replace("ô", "ô");

            strReturn = strReturn.Replace("ớ", "ớ");
            strReturn = strReturn.Replace("ở", "ở");
            strReturn = strReturn.Replace("ỡ", "ỡ");
            strReturn = strReturn.Replace("ờ", "ờ");
            strReturn = strReturn.Replace("ợ", "ợ");
            strReturn = strReturn.Replace("ơ", "ơ");

            strReturn = strReturn.Replace("ó", "ó");
            strReturn = strReturn.Replace("ỏ", "ỏ");
            strReturn = strReturn.Replace("õ", "õ");
            strReturn = strReturn.Replace("ò", "ò");
            strReturn = strReturn.Replace("ọ", "ọ");

            strReturn = strReturn.Replace("ứ", "ứ");
            strReturn = strReturn.Replace("ử", "ử");
            strReturn = strReturn.Replace("ữ", "ữ");
            strReturn = strReturn.Replace("ừ", "ừ");
            strReturn = strReturn.Replace("ự", "ự");
            strReturn = strReturn.Replace("ư", "ư");

            strReturn = strReturn.Replace("ú", "ú");
            strReturn = strReturn.Replace("ủ", "ủ");
            strReturn = strReturn.Replace("ũ", "ũ");
            strReturn = strReturn.Replace("ù", "ù");
            strReturn = strReturn.Replace("ụ", "ụ");

            strReturn = strReturn.Replace("ý", "ý");
            strReturn = strReturn.Replace("ỷ", "ỷ");
            strReturn = strReturn.Replace("ỹ", "ỹ");
            strReturn = strReturn.Replace("ỳ", "ỳ");
            strReturn = strReturn.Replace("ỵ", "y");

            strReturn = strReturn.Replace("Ắ", "Ắ");
            strReturn = strReturn.Replace("Ẳ", "Ẳ");
            strReturn = strReturn.Replace("Ẵ", "Ẵ");
            strReturn = strReturn.Replace("Ằ", "Ằ");
            strReturn = strReturn.Replace("Ặ", "Ặ");
            strReturn = strReturn.Replace("Ă", "Ă");

            strReturn = strReturn.Replace("Ấ", "Ấ");
            strReturn = strReturn.Replace("Ẩ", "Ẩ");
            strReturn = strReturn.Replace("Ẫ", "Ẫ");
            strReturn = strReturn.Replace("Ầ", "Ầ");
            strReturn = strReturn.Replace("Ậ", "Ậ");
            strReturn = strReturn.Replace("Â", "Â");

            strReturn = strReturn.Replace("Á", "Á");
            strReturn = strReturn.Replace("Ả", "Ả");
            strReturn = strReturn.Replace("Ã", "Ã");
            strReturn = strReturn.Replace("À", "À");
            strReturn = strReturn.Replace("Ạ", "Ạ");

            strReturn = strReturn.Replace("Đ", "Đ");

            strReturn = strReturn.Replace("Ế", "Ế");
            strReturn = strReturn.Replace("Ể", "Ể");
            strReturn = strReturn.Replace("Ễ", "Ễ");
            strReturn = strReturn.Replace("Ề", "Ề");
            strReturn = strReturn.Replace("Ệ", "Ệ");
            strReturn = strReturn.Replace("Ê", "Ê");

            strReturn = strReturn.Replace("É", "É");
            strReturn = strReturn.Replace("Ẻ", "Ẻ");
            strReturn = strReturn.Replace("Ẽ", "Ẽ");
            strReturn = strReturn.Replace("È", "È");
            strReturn = strReturn.Replace("Ẹ", "Ẹ");

            strReturn = strReturn.Replace("Í", "Í");
            strReturn = strReturn.Replace("Ỉ", "Ỉ");
            strReturn = strReturn.Replace("Ĩ", "Ĩ");
            strReturn = strReturn.Replace("Ì", "Ì");
            strReturn = strReturn.Replace("Ị", "Ị");

            strReturn = strReturn.Replace("Ố", "Ố");
            strReturn = strReturn.Replace("Ổ", "Ổ");
            strReturn = strReturn.Replace("Ỗ", "Ỗ");
            strReturn = strReturn.Replace("Ồ", "Ồ");
            strReturn = strReturn.Replace("Ộ", "Ộ");
            strReturn = strReturn.Replace("Ô", "Ô");

            strReturn = strReturn.Replace("Ớ", "Ớ");
            strReturn = strReturn.Replace("Ở", "Ở");
            strReturn = strReturn.Replace("Ỡ", "Ỡ");
            strReturn = strReturn.Replace("Ờ", "Ờ");
            strReturn = strReturn.Replace("Ợ", "Ợ");
            strReturn = strReturn.Replace("Ơ", "Ơ");

            strReturn = strReturn.Replace("Ó", "Ó");
            strReturn = strReturn.Replace("Ỏ", "Ỏ");
            strReturn = strReturn.Replace("Õ", "Õ");
            strReturn = strReturn.Replace("Ò", "Ò");
            strReturn = strReturn.Replace("Ọ", "Ọ");

            strReturn = strReturn.Replace("Ứ", "Ứ");
            strReturn = strReturn.Replace("Ử", "Ử");
            strReturn = strReturn.Replace("Ữ", "Ữ");
            strReturn = strReturn.Replace("Ừ", "Ừ");
            strReturn = strReturn.Replace("Ự", "Ự");
            strReturn = strReturn.Replace("Ư", "Ư");

            strReturn = strReturn.Replace("Ú", "Ú");
            strReturn = strReturn.Replace("Ủ", "Ủ");
            strReturn = strReturn.Replace("Ũ", "Ữ");
            strReturn = strReturn.Replace("Ù", "Ù");
            strReturn = strReturn.Replace("Ụ", "Ụ");

            strReturn = strReturn.Replace("Ý", "Ý");
            strReturn = strReturn.Replace("Ỷ", "Ỷ");
            strReturn = strReturn.Replace("Ỹ", "Ỹ");
            strReturn = strReturn.Replace("Ỳ", "Ỳ");
            strReturn = strReturn.Replace("Ỵ", "Ỵ");

            #endregion

            return strReturn;
        }

        /// <summary>
        /// Chuyển về chuỗi in thường
        /// </summary>
        /// <param name="source">Chuỗi nguồn</param>
        /// <returns>Chuỗi kết quả</returns>
        public static string Convert2Lower(string source)
        {
            if (string.IsNullOrEmpty(source)) return "";
            string strReturn = source;

            #region Unicode -> TCVN 6909

            strReturn = strReturn.Replace("Ắ", "ắ");
            strReturn = strReturn.Replace("Ẳ", "ẳ");
            strReturn = strReturn.Replace("Ẵ", "ẵ");
            strReturn = strReturn.Replace("Ằ", "ằ");
            strReturn = strReturn.Replace("Ặ", "ặ");
            strReturn = strReturn.Replace("Ă", "ă");

            strReturn = strReturn.Replace("Ấ", "ấ");
            strReturn = strReturn.Replace("Ẩ", "ẩ");
            strReturn = strReturn.Replace("Ẫ", "ẫ");
            strReturn = strReturn.Replace("Ầ", "ầ");
            strReturn = strReturn.Replace("Ậ", "ậ");
            strReturn = strReturn.Replace("Â", "â");

            strReturn = strReturn.Replace("Á", "á");
            strReturn = strReturn.Replace("Ả", "ả");
            strReturn = strReturn.Replace("Ã", "ã");
            strReturn = strReturn.Replace("À", "à");
            strReturn = strReturn.Replace("Ạ", "ạ");

            strReturn = strReturn.Replace("Đ", "đ");

            strReturn = strReturn.Replace("Ế", "ế");
            strReturn = strReturn.Replace("Ể", "ể");
            strReturn = strReturn.Replace("Ễ", "ễ");
            strReturn = strReturn.Replace("Ề", "ề");
            strReturn = strReturn.Replace("Ệ", "ệ");
            strReturn = strReturn.Replace("Ê", "ê");

            strReturn = strReturn.Replace("É", "é");
            strReturn = strReturn.Replace("Ẻ", "ẻ");
            strReturn = strReturn.Replace("Ẽ", "ẽ");
            strReturn = strReturn.Replace("È", "è");
            strReturn = strReturn.Replace("Ẹ", "ẹ");

            strReturn = strReturn.Replace("Í", "í");
            strReturn = strReturn.Replace("Ỉ", "ỉ");
            strReturn = strReturn.Replace("Ĩ", "ĩ");
            strReturn = strReturn.Replace("Ì", "ì");
            strReturn = strReturn.Replace("Ị", "ị");

            strReturn = strReturn.Replace("Ố", "ố");
            strReturn = strReturn.Replace("Ổ", "ổ");
            strReturn = strReturn.Replace("Ỗ", "ỗ");
            strReturn = strReturn.Replace("Ồ", "ồ");
            strReturn = strReturn.Replace("Ộ", "ộ");
            strReturn = strReturn.Replace("Ô", "ô");

            strReturn = strReturn.Replace("Ớ", "ớ");
            strReturn = strReturn.Replace("Ở", "ở");
            strReturn = strReturn.Replace("Ỡ", "ỡ");
            strReturn = strReturn.Replace("Ờ", "ờ");
            strReturn = strReturn.Replace("Ợ", "ợ");
            strReturn = strReturn.Replace("Ơ", "ơ");

            strReturn = strReturn.Replace("Ó", "ó");
            strReturn = strReturn.Replace("Ỏ", "ỏ");
            strReturn = strReturn.Replace("Õ", "õ");
            strReturn = strReturn.Replace("Ò", "ò");
            strReturn = strReturn.Replace("Ọ", "ọ");

            strReturn = strReturn.Replace("Ứ", "ứ");
            strReturn = strReturn.Replace("Ử", "ử");
            strReturn = strReturn.Replace("Ữ", "ữ");
            strReturn = strReturn.Replace("Ừ", "ừ");
            strReturn = strReturn.Replace("Ự", "ự");
            strReturn = strReturn.Replace("Ư", "ư");

            strReturn = strReturn.Replace("Ú", "ú");
            strReturn = strReturn.Replace("Ủ", "ủ");
            strReturn = strReturn.Replace("Ũ", "ũ");
            strReturn = strReturn.Replace("Ù", "ù");
            strReturn = strReturn.Replace("Ụ", "ụ");

            strReturn = strReturn.Replace("Ý", "ý");
            strReturn = strReturn.Replace("Ỷ", "ỷ");
            strReturn = strReturn.Replace("Ỹ", "ỹ");
            strReturn = strReturn.Replace("Ỳ", "ỳ");
            strReturn = strReturn.Replace("Ỵ", "ỵ");

            #endregion

            #region Unicode tổ hợp -> Unicode vietnamese

            strReturn = strReturn.Replace("Ắ", "ắ");
            strReturn = strReturn.Replace("Ẳ", "ẳ");
            strReturn = strReturn.Replace("Ẵ", "ẵ");
            strReturn = strReturn.Replace("Ằ", "ằ");
            strReturn = strReturn.Replace("Ặ", "ặ");
            strReturn = strReturn.Replace("Ă", "ă");

            strReturn = strReturn.Replace("Ấ", "ấ");
            strReturn = strReturn.Replace("Ẩ", "ẩ");
            strReturn = strReturn.Replace("Ẫ", "ẫ");
            strReturn = strReturn.Replace("Ầ", "ầ");
            strReturn = strReturn.Replace("Ậ", "ậ");
            strReturn = strReturn.Replace("Â", "â");

            strReturn = strReturn.Replace("Á", "á");
            strReturn = strReturn.Replace("Ả", "ả");
            strReturn = strReturn.Replace("Ã", "ã");
            strReturn = strReturn.Replace("À", "à");
            strReturn = strReturn.Replace("Ạ", "ạ");

            strReturn = strReturn.Replace("Đ", "đ");

            strReturn = strReturn.Replace("Ế", "ế");
            strReturn = strReturn.Replace("Ể", "ể");
            strReturn = strReturn.Replace("Ễ", "ễ");
            strReturn = strReturn.Replace("Ề", "ề");
            strReturn = strReturn.Replace("Ệ", "ệ");
            strReturn = strReturn.Replace("Ê", "ê");

            strReturn = strReturn.Replace("É", "é");
            strReturn = strReturn.Replace("Ẻ", "ẻ");
            strReturn = strReturn.Replace("Ẽ", "ẽ");
            strReturn = strReturn.Replace("È", "è");
            strReturn = strReturn.Replace("Ẹ", "ẹ");

            strReturn = strReturn.Replace("Í", "í");
            strReturn = strReturn.Replace("Ỉ", "ỉ");
            strReturn = strReturn.Replace("Ĩ", "ĩ");
            strReturn = strReturn.Replace("Ì", "ì");
            strReturn = strReturn.Replace("Ị", "ị");

            strReturn = strReturn.Replace("Ố", "ố");
            strReturn = strReturn.Replace("Ổ", "ổ");
            strReturn = strReturn.Replace("Ỗ", "ỗ");
            strReturn = strReturn.Replace("Ồ", "ồ");
            strReturn = strReturn.Replace("Ộ", "ộ");
            strReturn = strReturn.Replace("Ô", "ô");

            strReturn = strReturn.Replace("Ớ", "ớ");
            strReturn = strReturn.Replace("Ở", "ở");
            strReturn = strReturn.Replace("Ỡ", "ỡ");
            strReturn = strReturn.Replace("Ờ", "ờ");
            strReturn = strReturn.Replace("Ợ", "ợ");
            strReturn = strReturn.Replace("Ơ", "ơ");

            strReturn = strReturn.Replace("Ó", "ó");
            strReturn = strReturn.Replace("Ỏ", "ỏ");
            strReturn = strReturn.Replace("Õ", "õ");
            strReturn = strReturn.Replace("Ò", "ò");
            strReturn = strReturn.Replace("Ọ", "ọ");

            strReturn = strReturn.Replace("Ứ", "ứ");
            strReturn = strReturn.Replace("Ử", "ử");
            strReturn = strReturn.Replace("Ữ", "ữ");
            strReturn = strReturn.Replace("Ừ", "ừ");
            strReturn = strReturn.Replace("Ự", "ự");
            strReturn = strReturn.Replace("Ư", "ư");

            strReturn = strReturn.Replace("Ú", "ú");
            strReturn = strReturn.Replace("Ủ", "ủ");
            strReturn = strReturn.Replace("Ũ", "ũ");
            strReturn = strReturn.Replace("Ù", "ù");
            strReturn = strReturn.Replace("Ụ", "ụ");

            strReturn = strReturn.Replace("Ý", "ý");
            strReturn = strReturn.Replace("Ỷ", "ỷ");
            strReturn = strReturn.Replace("Ỹ", "ỹ");
            strReturn = strReturn.Replace("Ỳ", "ỳ");
            strReturn = strReturn.Replace("Ỵ", "ỵ");

            #endregion

            strReturn = strReturn.ToLower();
            return strReturn;
        }

        /// <summary>
        /// Chuyển về chuỗi in hoa
        /// </summary>
        /// <param name="source">Chuỗi nguồn</param>
        /// <returns>Chuỗi kết quả</returns>
        public static string Convert2Upper(string source)
        {
            string strReturn = source;

            #region Unicode -> TCVN 6909

            strReturn = strReturn.Replace("ắ", "Ắ");
            strReturn = strReturn.Replace("ẳ", "Ẳ");
            strReturn = strReturn.Replace("ẵ", "Ẵ");
            strReturn = strReturn.Replace("ằ", "Ằ");
            strReturn = strReturn.Replace("ặ", "Ặ");
            strReturn = strReturn.Replace("ă", "Ă");

            strReturn = strReturn.Replace("ấ", "Ấ");
            strReturn = strReturn.Replace("ẩ", "Ẩ");
            strReturn = strReturn.Replace("ẫ", "Ẫ");
            strReturn = strReturn.Replace("ầ", "Ầ");
            strReturn = strReturn.Replace("ậ", "Ậ");
            strReturn = strReturn.Replace("â", "Â");

            strReturn = strReturn.Replace("á", "Á");
            strReturn = strReturn.Replace("ả", "Ả");
            strReturn = strReturn.Replace("ã", "Ã");
            strReturn = strReturn.Replace("à", "À");
            strReturn = strReturn.Replace("ạ", "Ạ");

            strReturn = strReturn.Replace("đ", "Đ");

            strReturn = strReturn.Replace("ế", "Ế");
            strReturn = strReturn.Replace("ể", "Ể");
            strReturn = strReturn.Replace("ễ", "Ễ");
            strReturn = strReturn.Replace("ề", "Ề");
            strReturn = strReturn.Replace("ệ", "Ệ");
            strReturn = strReturn.Replace("ê", "Ê");

            strReturn = strReturn.Replace("é", "É");
            strReturn = strReturn.Replace("ẻ", "Ẻ");
            strReturn = strReturn.Replace("ẽ", "Ẽ");
            strReturn = strReturn.Replace("è", "È");
            strReturn = strReturn.Replace("ẹ", "Ẹ");

            strReturn = strReturn.Replace("í", "Í");
            strReturn = strReturn.Replace("ỉ", "Ỉ");
            strReturn = strReturn.Replace("ĩ", "Ĩ");
            strReturn = strReturn.Replace("ì", "Ì");
            strReturn = strReturn.Replace("ị", "Ị");

            strReturn = strReturn.Replace("ố", "Ố");
            strReturn = strReturn.Replace("ổ", "Ổ");
            strReturn = strReturn.Replace("ỗ", "Ỗ");
            strReturn = strReturn.Replace("ồ", "Ồ");
            strReturn = strReturn.Replace("ộ", "Ộ");
            strReturn = strReturn.Replace("ô", "Ô");

            strReturn = strReturn.Replace("ớ", "Ớ");
            strReturn = strReturn.Replace("ở", "Ở");
            strReturn = strReturn.Replace("ỡ", "Ỡ");
            strReturn = strReturn.Replace("ờ", "Ờ");
            strReturn = strReturn.Replace("ợ", "Ợ");
            strReturn = strReturn.Replace("ơ", "Ơ");

            strReturn = strReturn.Replace("ó", "Ó");
            strReturn = strReturn.Replace("ỏ", "Ỏ");
            strReturn = strReturn.Replace("õ", "Õ");
            strReturn = strReturn.Replace("ò", "Ò");
            strReturn = strReturn.Replace("ọ", "Ọ");

            strReturn = strReturn.Replace("ứ", "Ứ");
            strReturn = strReturn.Replace("ử", "Ử");
            strReturn = strReturn.Replace("ữ", "Ữ");
            strReturn = strReturn.Replace("ừ", "Ừ");
            strReturn = strReturn.Replace("ự", "Ự");
            strReturn = strReturn.Replace("ư", "Ư");

            strReturn = strReturn.Replace("ú", "Ú");
            strReturn = strReturn.Replace("ủ", "Ủ");
            strReturn = strReturn.Replace("ũ", "Ũ");
            strReturn = strReturn.Replace("ù", "Ù");
            strReturn = strReturn.Replace("ụ", "Ụ");

            strReturn = strReturn.Replace("ý", "Ý");
            strReturn = strReturn.Replace("ỷ", "Ỷ");
            strReturn = strReturn.Replace("ỹ", "Ỹ");
            strReturn = strReturn.Replace("ỳ", "Ỳ");
            strReturn = strReturn.Replace("ỵ", "Ỵ");

            #endregion

            #region Unicode tổ hợp -> Unicode Vietnamese

            strReturn = strReturn.Replace("ắ", "Ắ");
            strReturn = strReturn.Replace("ẳ", "Ẳ");
            strReturn = strReturn.Replace("ẵ", "Ẵ");
            strReturn = strReturn.Replace("ằ", "Ằ");
            strReturn = strReturn.Replace("ặ", "Ặ");
            strReturn = strReturn.Replace("ă", "Ă");

            strReturn = strReturn.Replace("ấ", "Ấ");
            strReturn = strReturn.Replace("ẩ", "Ẩ");
            strReturn = strReturn.Replace("ẫ", "Ẫ");
            strReturn = strReturn.Replace("ầ", "Ầ");
            strReturn = strReturn.Replace("ậ", "Ậ");
            strReturn = strReturn.Replace("â", "Â");

            strReturn = strReturn.Replace("á", "Á");
            strReturn = strReturn.Replace("ả", "Ả");
            strReturn = strReturn.Replace("ã", "Ã");
            strReturn = strReturn.Replace("à", "À");
            strReturn = strReturn.Replace("ạ", "Ạ");

            strReturn = strReturn.Replace("đ", "Đ");

            strReturn = strReturn.Replace("ế", "Ế");
            strReturn = strReturn.Replace("ể", "Ể");
            strReturn = strReturn.Replace("ễ", "Ễ");
            strReturn = strReturn.Replace("ề", "Ề");
            strReturn = strReturn.Replace("ệ", "Ệ");
            strReturn = strReturn.Replace("ê", "Ê");

            strReturn = strReturn.Replace("é", "É");
            strReturn = strReturn.Replace("ẻ", "Ẻ");
            strReturn = strReturn.Replace("ẽ", "Ẽ");
            strReturn = strReturn.Replace("è", "È");
            strReturn = strReturn.Replace("ẹ", "Ẹ");

            strReturn = strReturn.Replace("í", "Í");
            strReturn = strReturn.Replace("ỉ", "Ỉ");
            strReturn = strReturn.Replace("ĩ", "Ĩ");
            strReturn = strReturn.Replace("ì", "Ì");
            strReturn = strReturn.Replace("ị", "Ị");

            strReturn = strReturn.Replace("ố", "Ố");
            strReturn = strReturn.Replace("ổ", "Ổ");
            strReturn = strReturn.Replace("ỗ", "Ỗ");
            strReturn = strReturn.Replace("ồ", "Ồ");
            strReturn = strReturn.Replace("ộ", "Ộ");
            strReturn = strReturn.Replace("ô", "Ô");

            strReturn = strReturn.Replace("ớ", "Ớ");
            strReturn = strReturn.Replace("ở", "Ở");
            strReturn = strReturn.Replace("ỡ", "Ỡ");
            strReturn = strReturn.Replace("ờ", "Ờ");
            strReturn = strReturn.Replace("ợ", "Ợ");
            strReturn = strReturn.Replace("ơ", "Ơ");

            strReturn = strReturn.Replace("ó", "Ó");
            strReturn = strReturn.Replace("ỏ", "Ỏ");
            strReturn = strReturn.Replace("õ", "Õ");
            strReturn = strReturn.Replace("ò", "Ò");
            strReturn = strReturn.Replace("ọ", "Ọ");

            strReturn = strReturn.Replace("ứ", "Ứ");
            strReturn = strReturn.Replace("ử", "Ử");
            strReturn = strReturn.Replace("ữ", "Ữ");
            strReturn = strReturn.Replace("ừ", "Ừ");
            strReturn = strReturn.Replace("ự", "Ự");
            strReturn = strReturn.Replace("ư", "Ư");

            strReturn = strReturn.Replace("ú", "Ú");
            strReturn = strReturn.Replace("ủ", "Ủ");
            strReturn = strReturn.Replace("ũ", "Ũ");
            strReturn = strReturn.Replace("ù", "Ù");
            strReturn = strReturn.Replace("ụ", "Ụ");

            strReturn = strReturn.Replace("ý", "Ý");
            strReturn = strReturn.Replace("ỷ", "Ỷ");
            strReturn = strReturn.Replace("ỹ", "Ỹ");
            strReturn = strReturn.Replace("ỳ", "Ỳ");
            strReturn = strReturn.Replace("ỵ", "Ỵ");

            #endregion

            strReturn = strReturn.ToUpper();
            return strReturn;
        }

        /// <summary>
        /// Chuyển số tự nhiên về số La Mã
        /// </summary>
        /// <param name="number">Số tự nhiên</param>
        /// <returns>Số la mã</returns>
        public static string ConvertNumberToRoman(int number)
        {
            if (number < 0 || number > 3999)
            {
                throw new Exception("Value must be in the range 0 – 3,999.");
            }

            if (number == 0)
            {
                return "N";
            }

            int[] values = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] numerals = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < 13; i++)
            {
                while (number >= values[i])
                {
                    number -= values[i];
                    result.Append(numerals[i]);
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Mã hóa chuỗi
        /// </summary>
        /// <param name="toEncrypt">Chuỗi cần mã hóa</param>
        /// <param name="useHashing">Sử dụng Hash</param>
        /// <returns>Chuỗi đã mã hóa</returns>
        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] arrKey;
            byte[] arrInputString = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            string strKey = "@dm1n:P@ssw0rd=M@tKh@u";
            if (useHashing)
            {
                MD5CryptoServiceProvider objHashMd5 = new MD5CryptoServiceProvider();
                arrKey = objHashMd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(strKey));
                objHashMd5.Clear();
            }
            else
            {
                arrKey = UTF8Encoding.UTF8.GetBytes(strKey);
            }

            TripleDESCryptoServiceProvider objEncryptProvider = new TripleDESCryptoServiceProvider();
            objEncryptProvider.Key = arrKey;
            objEncryptProvider.Mode = CipherMode.ECB;
            objEncryptProvider.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = objEncryptProvider.CreateEncryptor();
            byte[] arrResult = cTransform.TransformFinalBlock(arrInputString, 0, arrInputString.Length);
            objEncryptProvider.Clear();
            return Convert.ToBase64String(arrResult, 0, arrResult.Length);
        }

        /// <summary>
        /// Giải mã chuỗi
        /// </summary>
        /// <param name="cipherString">Chuỗi cần giải mã</param>
        /// <param name="useHashing">Sử dụng Hash</param>
        /// <returns>Chuỗi đã giải mã</returns>
        public static string Decrypt(string cipherString, bool useHashing)
        {
            byte[] arrayKey;
            byte[] arrInputString = Convert.FromBase64String(cipherString);

            string strKey = "@dm1n:P@ssw0rd=M@tKh@u";
            if (useHashing)
            {
                MD5CryptoServiceProvider objHashMd5 = new MD5CryptoServiceProvider();
                arrayKey = objHashMd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(strKey));
                objHashMd5.Clear();
            }
            else
            {
                arrayKey = UTF8Encoding.UTF8.GetBytes(strKey);
            }

            TripleDESCryptoServiceProvider objDecryptProvider = new TripleDESCryptoServiceProvider();
            objDecryptProvider.Key = arrayKey;
            objDecryptProvider.Mode = CipherMode.ECB;
            objDecryptProvider.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = objDecryptProvider.CreateDecryptor();
            byte[] arrResult = cTransform.TransformFinalBlock(arrInputString, 0, arrInputString.Length);
            objDecryptProvider.Clear();
            return UTF8Encoding.UTF8.GetString(arrResult);
        }

        #endregion
    }
}