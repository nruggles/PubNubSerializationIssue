using Newtonsoft.Json;
using NUnit.Framework;
using PNSerializerExample.Infrastructure;
using PNSerializerExample.Models;
using PubnubApi;

namespace PNSerializerExample;

[TestFixture]
public class SerializationExamples
{
    [SetUp]
    public void Setup()
    {
        //reset default settings for each test
        JsonConvert.DefaultSettings = () => Constants.DefaultSettings;
    }
    
    [Test]
    public void AfterPubnubSDKIsInstantiated_ItDoesNotSerializeCorrectly()
    {
        var model = MockData.Get<User>();
        var serialized = JsonConvert.SerializeObject(model);
        Console.WriteLine($"Before:\n{serialized}");

        //do nothing except for instantiate the SDK
        var sdk = new Pubnub(new PNConfiguration(new UserId(Guid.NewGuid().ToString())));
        
        //then re-serialize the same object
        var afterSdkSerialized = JsonConvert.SerializeObject(model);
        Console.WriteLine($"After:\n{afterSdkSerialized}");
        
        //note that this validation fails
        Assert.That(afterSdkSerialized, Is.EqualTo(serialized));
    }
    
    [Test]
    public void WhenPubnubSDKIsNotInstantiated_ItDoesSerializeCorrectly()
    {
        //do the exact same thing as the test above but do not instantiate the SDK
        var model = MockData.Get<User>();
        var serialized = JsonConvert.SerializeObject(model);
        Console.WriteLine($"Before:\n{serialized}");
        
        //then re-serialize the same object
        var afterSdkSerialized = JsonConvert.SerializeObject(model);
        Console.WriteLine($"After:\n{afterSdkSerialized}");
        
        //note that this validation passes
        Assert.That(afterSdkSerialized, Is.EqualTo(serialized));
    }
}