﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Translate.Core.Translator;
using Translate.Core.Translator.Entities;
using Translate.Core.Translator.Youdao;

namespace VsTranslatorTest
{
    [TestClass]
    public class YoudaoTranslatorTest
    {
        readonly ITranslator _youdaoTranslator = new YoudaoTranslator("zhiyue", "702916626");

        [TestMethod]
        public void Translate()
        {
            string sourceText = "TDD completely turns traditional development around.";
            TranslationResult transResult = _youdaoTranslator.Translate(sourceText, "EN", "ZH_CN");
            Assert.AreEqual("TDD完全变成传统的开发。", transResult.TargetText);

            sourceText = "你今天过得好不好";
            transResult = _youdaoTranslator.Translate(sourceText, "ZH_CN", "EN");
            Assert.AreEqual("Did you have a good day today", transResult.TargetText);

            sourceText = "hello\"";
            transResult = _youdaoTranslator.Translate(sourceText, "EN", "ZH_CN");
            //Assert.AreEqual("去\"", transResult.TargetText);//当使用有道api的时候是去
            Assert.AreEqual("你好”", transResult.TargetText);//这是有道网站的接口

            sourceText = "hello";
            transResult = _youdaoTranslator.Translate(sourceText, "EN", "ZH_CN");
            Assert.AreEqual("你好", transResult.TargetText);

            sourceText = "<result>";
            transResult = _youdaoTranslator.Translate(sourceText, "EN", "ZH_CN");
            Assert.AreEqual("<结果>", transResult.TargetText);
        }
    }
}