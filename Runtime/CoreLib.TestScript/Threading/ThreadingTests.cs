using System;
using System.Threading.Tasks;
using QUnit;
using System.Threading;

namespace CoreLib.TestScript.Threading
{
    [TestFixture]
    public class ThreadingTests
    {
        [Test]
        public void InterlockedCompareExchangeIntWorks()
        {
            var r = 1;
            Assert.AreEqual(1, Interlocked.CompareExchange(ref r, 2, 0));
            Assert.AreEqual(1, r);
            Assert.AreEqual(2, Interlocked.CompareExchange(ref r, 2, 1));
            Assert.AreEqual(2, r);
        }

        [Test]
        public void InterlockedCompareExchangeGenericWorks()
        {
            var r = "hello";
            Assert.AreEqual("hello", Interlocked.CompareExchange<string>(ref r, "bye", "hey"));
            Assert.AreEqual("hello", r);
            Assert.AreEqual("bye", Interlocked.CompareExchange<string>(ref r, "bye", "hello"));
            Assert.AreEqual("bye", r);
        }

        [Test]
        public void InterlockedIncrementWorks()
        {
            var r = 1;
            Assert.AreEqual(2, Interlocked.Increment(ref r));
            Assert.AreEqual(2, r);
        }
    }
}
