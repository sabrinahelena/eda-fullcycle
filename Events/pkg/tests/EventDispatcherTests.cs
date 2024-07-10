using Events.pkg.events.interfaces;
using Events.pkg.events;
using NUnit.Framework;

namespace Events.pkg.tests
{
    [TestFixture]
    public class EventDispatcherTests
    {
        private IEventInterface testEvent;
        private IEventInterface testEvent2;
        private IEventHandlerInterface handler;
        private IEventHandlerInterface handler2;
        private IEventHandlerInterface handler3;
        private EventDispatcher eventDispatcher;

        [SetUp]
        public void SetUp()
        {
            testEvent = new TestEvent("TestEvent");
            testEvent2 = new TestEvent("TestEvent2");
            handler = new TestEventHandler();
            handler2 = new TestEventHandler();
            handler3 = new TestEventHandler();
            eventDispatcher = new EventDispatcher();
        }

        [Test]
        public void TestEventDispatcher_Register()
        {
            // Act
            eventDispatcher.Register(testEvent.GetName(), handler);
            eventDispatcher.Register(testEvent.GetName(), handler2);

            // Assert
            Assert.That(eventDispatcher.Has(testEvent.GetName(), handler));
            Assert.That(eventDispatcher.Has(testEvent.GetName(), handler2));
        }

        [Test]
        public void TestEventDispatcher_Register_ThrowsException_WhenHandlerAlreadyRegistered()
        {
            // Arrange
            eventDispatcher.Register(testEvent.GetName(), handler);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => eventDispatcher.Register(testEvent.GetName(), handler));
        }

        [Test]
        public void TestEventDispatcher_Dispatch()
        {
            // Arrange
            eventDispatcher.Register(testEvent.GetName(), handler);
            var testEventInstance = (TestEvent)testEvent;
            testEventInstance.Handled = false;

            // Act
            eventDispatcher.Dispatch(testEvent);

            // Assert
            Assert.That(testEventInstance.Handled, Is.True);
        }

        [Test]
        public void TestEventDispatcher_Remove()
        {
            // Arrange
            eventDispatcher.Register(testEvent.GetName(), handler);
            eventDispatcher.Register(testEvent.GetName(), handler2);

            // Act
            eventDispatcher.Remove(testEvent.GetName(), handler);

            // Assert
            Assert.That(eventDispatcher.Has(testEvent.GetName(), handler), Is.False);
            Assert.That(eventDispatcher.Has(testEvent.GetName(), handler2), Is.True);
        }

        [Test]
        public void TestEventDispatcher_Has()
        {
            // Act
            eventDispatcher.Register(testEvent.GetName(), handler);

            // Assert
            Assert.That(eventDispatcher.Has(testEvent.GetName(), handler), Is.True);
            Assert.That(eventDispatcher.Has(testEvent.GetName(), handler2), Is.False);
        }

        [Test]
        public void TestEventDispatcher_Clear()
        {
            // Act
            eventDispatcher.Register(testEvent.GetName(), handler);
            eventDispatcher.Clear();

            // Assert
            Assert.That(eventDispatcher.Has(testEvent.GetName(), handler), Is.False);
        }

        private class TestEvent : IEventInterface
        {
            private string name;

            public TestEvent(string name)
            {
                this.name = name;
            }

            public string GetName()
            {
                return name;
            }

            public DateTime GetDateTime()
            {
                return DateTime.Now;
            }

            public object GetPayload()
            {
                return null;
            }

            public bool Handled { get; set; }
        }

        private class TestEventHandler : IEventHandlerInterface
        {
            public void Handle(IEventInterface eventInstance)
            {
                if (eventInstance is TestEvent testEvent)
                {
                    testEvent.Handled = true;
                }
            }
        }
    }
}