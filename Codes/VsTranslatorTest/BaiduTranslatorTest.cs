﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Translate.Core.Translator;
using Translate.Core.Translator.Baidu;
using Translate.Core.Translator.Entities;

namespace VsTranslatorTest
{
    [TestClass]
    public class BaiduTranslatorTest
    {
        readonly ITranslator _baiduTranslator = new BaiduTranslator("20161214000033991", "HMlukU9THx2Twx1I14Hz");
        [TestMethod]
        public void Translate()
        {
            string sourceText = "TDD completely turns traditional development around.";
            TranslationResult transResult = _baiduTranslator.Translate(sourceText, "en", "zh");
            Assert.IsNotNull(transResult);
            Assert.AreEqual("TDD完全改变了传统的发展方向。", transResult.TargetText);

            sourceText = "你今天过得好不好";
            transResult = _baiduTranslator.Translate(sourceText, "zh", "en");
            Assert.IsNotNull(transResult);
            Assert.AreEqual("Do you have a good day", transResult.TargetText);

            sourceText = "hello\"";
             transResult = _baiduTranslator.Translate(sourceText, "en", "zh");
            Assert.IsNotNull(transResult);
            Assert.AreEqual("你好”", transResult.TargetText);

            sourceText = "hello";
            transResult = _baiduTranslator.Translate(sourceText, "en", "zh");
            Assert.IsNotNull(transResult);
            Assert.AreEqual("你好", transResult.TargetText);


            sourceText = "<result>";
            transResult = _baiduTranslator.Translate(sourceText, "en", "zh");
            Assert.AreEqual("<结果>", transResult.TargetText);

        }
    }
}