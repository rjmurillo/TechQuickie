using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwoStackQueue;

namespace UnitTest
{
    public abstract class TestContext
    {
        [TestInitialize]
        public void TestInitialize()
        {
            Arrange();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Cleanup();
        }

        public virtual void Arrange()
        {
        }

        public virtual void Cleanup()
        {
        }
    }

    public abstract class QueueTestBase<TItem> : TestContext
    {
        protected IQueue<TItem> _instance;
        protected TItem _expected;
        protected TItem _actual;
    }

    public abstract class QueueDefaultTestBase<TItem> : QueueTestBase<TItem>
    {
        public override void Arrange()
        {
            _instance = new Queue<TItem>();
        }
    }

    [TestClass]
    public class DequeueEmpty : QueueDefaultTestBase<int>
    {
        [TestMethod]
        public void ValueIsDefaultForType()
        {
            _actual = _instance.Dequeue();
            Assert.AreEqual(_expected, _actual);
        }
    }

    [TestClass]
    public class CanEnqueue : QueueDefaultTestBase<int>
    {
        [TestMethod]
        public void EnqueueNoException()
        {
            _instance.Enqueue(1);
        }
    }

    [TestClass]
    public class CanDequeueASingleItem : QueueDefaultTestBase<int>
    {
        public override void Arrange()
        {
            base.Arrange();

            _expected = 1;

            _instance.Enqueue(_expected);
        }

        [TestMethod]
        public void DequeueIsExpectedValue()
        {
            _actual = _instance.Dequeue();

            Assert.AreEqual(_expected, _actual);
        }
    }

    [TestClass]
    public class CanDequeueMultipleItemsInARow : QueueDefaultTestBase<int>
    {
        public override void Arrange()
        {
            base.Arrange();

            _instance.Enqueue(1);
            _instance.Enqueue(2);
        }

        [TestMethod]
        public void ItemsAreInFIFO()
        {
            _expected = 1;
            _actual = _instance.Dequeue();

            Assert.AreEqual(_expected, _actual);

            _expected = 2;
            _actual = _instance.Dequeue();

            Assert.AreEqual(_expected, _actual);
        }
    }

    [TestClass]
    public class CanDequeueMultipleItemsAlternating : QueueDefaultTestBase<int>
    {
        public override void Arrange()
        {
            base.Arrange();

            _instance.Enqueue(1);
            _instance.Enqueue(2);
        }

        [TestMethod]
        public void ItemsAreInFIFO()
        {
            _expected = 1;
            _actual = _instance.Dequeue();

            Assert.AreEqual(_expected, _actual);

            // Enqueue
            _instance.Enqueue(3);

            _expected = 2;
            _actual = _instance.Dequeue();

            Assert.AreEqual(_expected, _actual);

            _expected = 3;
            _actual = _instance.Dequeue();

            Assert.AreEqual(_expected, _actual);
        }
    }
}
