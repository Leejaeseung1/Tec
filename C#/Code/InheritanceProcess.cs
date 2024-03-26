namespace C_.Code
{
    //interface is function
    //abstract is inheritance

    internal class InheritanceProcess
    {
        public void F()
        {
            Creature mon = new Monkey();
            mon.Live();

            Animal mon2 = mon as Animal;
            mon2.Live();
            mon2.Move();

            Monkey mon3 = mon as Monkey;
            mon3.Climbing();


            bool who = true; //specific condition
            Eatable eat = who ? new Monkey() : new CarnivorousPlant();
            eat.Eat(); //run interface
        }
    }

    abstract class Creature
    {
        public void Live() { }
    }

    abstract class Animal : Creature, Eatable //all animal can eat
    {
        public virtual void Eat() => throw new NotImplementedException();

        public void Move() { }
    }

    abstract class Plant : Creature
    { }

    class Monkey : Animal
    {
        public void Climbing() { }

        public override void Eat() => base.Eat();
    }

    class Human : Animal
    { }

    class Cactus : Plant //no eat
    { }

    class CarnivorousPlant : Plant, Eatable
    {
        public void Eat() => throw new NotImplementedException();
    }

    interface Eatable
    {
        void Eat();
    }
}
