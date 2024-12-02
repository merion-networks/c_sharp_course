using MyFiveProgram;

Publisher publisher = new Publisher();

Subscriber subscriber1 = new Subscriber("A", publisher);
Subscriber subscriber2 = new Subscriber("B", publisher);
Subscriber subscriber3 = new Subscriber("C", publisher);
Subscriber subscriber4 = new Subscriber("D", publisher);


subscriber1.Subscribe();
subscriber2.Subscribe();
subscriber3.Subscribe();
subscriber4.Subscribe();


publisher.RaiseEvent($"Событие от {nameof(Publisher)}");

subscriber3.UnSubscribe();


publisher.RaiseEvent($"Второе событие от {nameof(Publisher)}");

Console.ReadKey();