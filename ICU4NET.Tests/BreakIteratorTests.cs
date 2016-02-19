using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ICU4NET.Tests
{
    [TestFixture]
    public class BreakIteratorTests
    {
        [Test]
        public void test_foo()
        {
            // setup
            Locale loc = Locale.GetUS();


            const string THE_TEXT = @"

พักหลังๆนี่เวลาแก๊นจะตัดสินใจซื้ออะไรซักอย่างที่มันมีราคา จะคิดแล้วคิดอีก อย่างน้อยก็ทิ้งเวลาไว้ตั้งแต่ 2 อาทิตย์ - หลายเดือน เพื่อจะดูว่าเราต้องการมันจริงๆรึเปล่า (ถ้าผ่านมานานแล้วก็ยังต้องการอยู่ก็แปลว่าโอเค ไม่ใช่ความรู้สึกชั่ววูบหลังดูโฆษณา)

ของเล่นชิ้นล่าสุดที่เอาเข้าบ้านคือ LCD TV ของ LG รุ่น LH70 ขนาด 32 นิ้ว กระเป๋าแห้งไปอีกหลายเดือน อยากถ่ายรูปที่ห้องเก็บไว้เหมือนกัน แต่ห้องรกจัด แหะๆ ผมแนะนำว่าซื้อกับร้านข้างนอกถูกกว่าในห้างมากจนน่าตกใจเลยนะครับ สุดท้ายมันก็ประกันศูนย์ LG เหมือนกัน

She stopped.  She said, ""Hello there,"" and then went on.

";

            BreakIterator sut = BreakIterator.CreateWordInstance(loc);

            sut.SetText(THE_TEXT);

            // test
            string clrText = sut.GetCLRText();

            int start = sut.First();

            int end = sut.Next();

            var words = new List<string>();

            while (end != BreakIterator.DONE)
            {
                string w = clrText.Substring(start,
                                             length: end - start);

                words.Add(w);

                start = end;
                end = sut.Next();
            }

            Console.WriteLine("words count: [{0:#,#}]", words.Count);

            // assertions
            Assert.That(words.Count == 191);
        }
    }
}
