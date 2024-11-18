using RentACar.Domain.Abstractions;
using RentACar.Domain.Users.Events;

namespace RentACar.Domain.Users
{
    public sealed class User : Entity
    {
        private User(
            Guid id,
            Name name,
            LastName lastName,
            Email email
            ) : base(id)
        {
            Name = name;
            LastName = lastName;
            Email = email;
        }

        public Name? Name { get; private set; }
        public LastName? LastName { get; private set; }
        public Email? Email { get; private set; }

        public static User Create(Name name, LastName lastName, Email email)
        {
            var user = new User(Guid.NewGuid(), name, lastName, email);
            user.RaiseDomainEvent(new UserCreateDomainEvent(user.Id));
            return user;
        }
    }
}
