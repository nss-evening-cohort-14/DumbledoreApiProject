# DumbledoreApiProject
# Description

You are an intrepid entrepreneur in the niche social network space.  Your latest trillion dollar idea is SpyDuh, a social network for spies.  This social network will allow spies to create SpyDuh accounts with their (im)personal details, including why they became a spy, as well as to socialize and find friends with similar skills.  You'll also be wanting a way to monetize this app, so having a section that allows for the listing of services is your entryway to the real money.  

You'll be building this in teams, and we're only concerned with building the API right now. 

## Example Repository Class

```csharp
class SpyRepository
{
    static List<Spy> _clinkers = new List<Spy>();

    public List<Spy> GetSpies()
    {
        throw new NotImplementedException();
    }

    public void SaveNewSpy(Spy newSpy)
    {
        throw new NotImplementedException();
    }
}
```

Your first task as a team will be to break down the following requirements into smaller chunks.  You are welcome to work on some tasks together, but everyone will need to have commits with substance.

# Requirements

As a Spy

I want to join a social network

So that I'm not so lonely

As SpyDuh member

I want to find other Spies by skills

So that I can make friends

As a SpyDuh member

I want to list my skills and services

So that other spies can ask me for help

As a SpyDuh member

I want to keep track of my friends

So that I can know who has my back

As a SpyDuh member

I want to keep track of my enemies

So that I know who to watch out for

# Stretch Goals

As a SpyDuh member

I want to know who my friends' friends are

So that I can build up my crew

As a Spy

I want to update and remove pieces of information, like skills and services

So that as I evolve as a person I can let everyone know

As a Handler

I want to get all spies' information for my agency

So that I can peruse the my available agents

As a Spy

I want to know how many days remain in my undercover assignment

So that I can keep track
