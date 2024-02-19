namespace ApiDotNet.Persons;

public class Person {
    public Guid Id { get; init; }
    public string Name { get; private set; }
    public int Age { get; private set; }

    public Person(string name, int age) {

        this.Id = Guid.NewGuid();
        this.Name = name;
        this.Age = age;

    }

    public void UpdatePerson(string name, int age){
        this.Name = name;
        this.Age = age;
    }
}
