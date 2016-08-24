using System;

namespace SamplePatterns
{
    public delegate void MessageActivateDelegate(string message);

    public interface IMediatorComponent
    {
        event MessageActivateDelegate MessageActivatedEvent;

        void Messsagactivation(string message);
    }

    public abstract class MessageActor
    {
        protected IMediatorComponent m_mediatorComponent;

        protected MessageActor(IMediatorComponent mediator)
        {
            m_mediatorComponent = mediator;
            m_mediatorComponent.MessageActivatedEvent += MessageRecevie;
        }

        protected abstract void MessageRecevie(string message);
    }

    public class PrimaryMessageActor : MessageActor
    {
        public PrimaryMessageActor(IMediatorComponent mediator)
            : base(mediator)
        {

        }

        protected override void MessageRecevie(string message)
        {
            Console.WriteLine("Priamary - {0}", message);
        }
    }

    public class SecondaryMessageActor : MessageActor
    {
        public SecondaryMessageActor(IMediatorComponent mediator)
            : base(mediator)
        {

        }

        protected override void MessageRecevie(string message)
        {
            Console.WriteLine("Secondary - {0}", message);
        }
    }

    public class MessageMediator : IMediatorComponent
    {
        public event MessageActivateDelegate MessageActivatedEvent;

        public void Messsagactivation(string message)
        {
            Console.WriteLine("MessageMediator - {0}", message);
            if (MessageActivatedEvent != null)
                MessageActivatedEvent(message);
        }
    }


    public class TestMediator
    {

        public static void Main()
        {
            IMediatorComponent mediator = new MessageMediator();
            PrimaryMessageActor primaryMessageActor = new PrimaryMessageActor(mediator);
            SecondaryMessageActor secondaryMessageActor = new SecondaryMessageActor(mediator);
            mediator.Messsagactivation("New Message");
            Console.ReadLine();
        }
    }
   
}
