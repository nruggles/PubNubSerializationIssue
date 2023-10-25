using Newtonsoft.Json;
using NUnit.Framework;
using PNSerializerExample.Infrastructure;
using PNSerializerExample.Models;
using PubnubApi;

namespace PNSerializerExample;

[TestFixture]
public class DeserializationExamples
{
    [SetUp]
    public void Setup()
    {
        //reset default settings for each test
        JsonConvert.DefaultSettings = () => Constants.DefaultSettings;
    }
    
    [Test]
    public void WhenPubnubSDKIsInstantiated_ItDoesNotDeserializeCorrectly()
    {
        //serialize and deserialize an object
        var model = MockData.Get<User>();
        var serialized = JsonConvert.SerializeObject(model);
        
        //do nothing except for instantiate the SDK
        var sdk = new Pubnub(new PNConfiguration(new UserId(Guid.NewGuid().ToString())));

        var deserialized = JsonConvert.DeserializeObject<User>(serialized);

        //note that this condition fails
        Assert.That(deserialized, Is.EqualTo(model));
    }
    
    [Test]
    public void WhenPubnubSDKIsNotInstantiated_ItDeserializesCorrectly()
    {
        //do the exact same thing as the test above but do not instantiate the SDK
        var model = MockData.Get<User>();
        var serialized = JsonConvert.SerializeObject(model);

        var deserialized = JsonConvert.DeserializeObject<User>(serialized);

        //note that this condition passes
        Assert.That(deserialized, Is.EqualTo(model));
    }
    
    
}