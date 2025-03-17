using System;
using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Resume.DTO;

namespace Resume.service
{
    class WordProcess
    {
        public static PersonInfo ReadWordFile(string file)
        {
            PersonInfo personInfo = null;
            try
            {
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(file, false))
                {
                    var mainPart = wordDoc.MainDocumentPart;
                    if (mainPart == null || mainPart.Document == null || mainPart.Document.Body == null)
                    {
                        Console.WriteLine("文档结构无效或为空");
                        return null;
                    }

                    personInfo = new PersonInfo();
                    Body body = mainPart.Document.Body;
                    IEnumerable<Table> tables = body.Elements<Table>();

                    // 检查是否找到表格
                    if (!tables.Any())
                    {
                        Console.WriteLine("文档中未找到任何表格，尝试解析段落内容...");
                        ParseParagraphs(body, personInfo);
                    }
                    else
                    {
                        Console.WriteLine($"找到 {tables.Count()} 个表格，开始解析...");
                        ParseTables(tables, personInfo);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"发生错误: {e.Message}");
                Console.WriteLine(e.StackTrace);
            }

            return personInfo;
        }

        // 解析表格
        private static void ParseTables(IEnumerable<Table> tables, PersonInfo personInfo)
        {
            var table = tables.FirstOrDefault();
            if (table != null) {
                foreach (TableRow row in table.Elements<TableRow>())
                {
                    TableCell[] cells = row.Elements<TableCell>().ToArray();
                    // 处理多列键值对（每行可能有多个键值对）
                    for (int i = 0; i < cells.Length - 1; i += 2)
                    {
                        string key = cells[i].InnerText.Trim();
                        string value = (i + 1 < cells.Length) ? cells[i + 1].InnerText.Trim() : "";

                        // 跳过图片或其他无关内容
                        if (string.IsNullOrEmpty(key) || key.Contains("照片")) continue;

                        AssignPersonInfo(personInfo, key, value);
                    }
                }
            }
                

        }

        // 解析段落（如果没有表格）
        private static void ParseParagraphs(Body body, PersonInfo personInfo)
        {
            foreach (Paragraph paragraph in body.Elements<Paragraph>())
            {
                string text = paragraph.InnerText.Trim();
                if (string.IsNullOrEmpty(text)) continue;

                // 假设使用制表符或空格分隔键值对
                string[] parts = text.Split(new[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < parts.Length - 1; i += 2)
                {
                    string key = parts[i].Trim();
                    string value = parts[i + 1].Trim();

                    // 跳过图片或其他无关内容
                    if (string.IsNullOrEmpty(key) || key.Contains("照片")) continue;

                    AssignPersonInfo(personInfo, key, value);
                }
            }
        }

        // 分配属性值
        private static void AssignPersonInfo(PersonInfo personInfo, string key, string value)
        {
            // 去除 key 中的所有空格并转换为小写，以统一格式
            key = key.Replace(" ", "").Replace("\u3000", "").ToLower();

            // 使用 Contains 检查 key 是否包含特定字段名
            if (key.Contains("姓名"))
                personInfo.Name = value;
            else if (key.Contains("性别"))
                personInfo.Gender = value;
            else if (key.Contains("出生年月"))
                personInfo.BirthDate = value;
            else if (key.Contains("民族"))
                personInfo.Ethnicity = value;
            else if (key.Contains("籍贯"))
                personInfo.NativePlace = value;
            else if (key.Contains("生源地"))
                personInfo.OriginPlace = value;
            else if (key.Contains("政治面貌"))
                personInfo.PoliticalStatus = value;
            else if (key.Contains("英语水平"))
                personInfo.EnglishLevel = value;
            else if (key.Contains("健康状况"))
                personInfo.HealthStatus = value;
            else if (key.Contains("毕业院校"))
                personInfo.University = value;
            else if (key.Contains("专业代码"))
                personInfo.MajorCode = value;
            else if (key.Contains("专业"))
                personInfo.Major = value;
            else if (key.Contains("预计取得学历学位证书时间"))
                personInfo.DegreeDate = value;
            else if (key.Contains("学历学位"))
                personInfo.Degree = value;
            else if (key.Contains("电子邮箱"))
                personInfo.Email = value;
            else if (key.Contains("手机电话"))
                personInfo.Phone = value;
            else if (key.Contains("身份证号"))
                personInfo.IDNumber = value;
            else if (key.Contains("求职岗位"))
                personInfo.JobPosition = value;
            // 可根据需要扩展其他字段
        }
    }
}
