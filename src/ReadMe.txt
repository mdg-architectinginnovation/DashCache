Items needed for Custom Implementation
-----------------------------------------------------------------------------------------------------------------------------------------
DashCache.CacheFramework
	Take everything

DashCache.Unit.Tests
	Take everything

DashCache.Web
	Web.config items
	CustomHttpModules\DashCacheFrameworkHttpModule
	Global.asax App_Start

Classes that have hardcoded values that should come from Config File
	DashCache.CacheFramework\InMemoryDashCacheManager.OnInMemoryDashCacheMonitorEvent
	DashCache.CacheFramework\DashCacheFrameworkHttpModuleBase.Init
	DashCache.Web\DashCacheFrameworkHttpModule.EndRequest
	DashCache.Web\Global.asax.App_Start 


Documenation
-----------------------------------------------------------------------------------------------------------------------------------------
Overview: DashCache allows you to cache items in memory.  It will allow you to add and evict individual items and it will allow you to set an 
expiration time in minutes and will evict items for you.  It uses the built in .net ConcurrencyDictionary because it is thread-safe by 
design.  The built in .net class MemoryCache was not used because the ConcurrencyDictionary is thread-safe by default and I
felt it was easier to write a custom timer, which MemoryCache has built in policy expiration.

Default settings expires items in the cache after a minute and monitors the cache in 30 second intervals

DashCache Framework Classes:
	DashCacheFrameworkHttpModuleBase - Http Module Base Abstract class used to have centralized logic on whether the Begin/End Http Request
		Events should fire.

	DashCacheFrameworkHttpModule - Http Module that inherits from DashCacheFrameworkHttpModuleBase.  You would implement this N number of services
		that your application has.  It contains logic for the Begin/End Http Request.  It will grab an item from the cache in the Begin Http Request based on the
		path and query string and store it in the HttpContext.Current.Items dictionary via the Cache Manager.  The End Http Request will check to see if the item in the 
		HttpContext.Current.Item via the Cache Manager has been cached and if not, cache it.  Also, it will check to see if the cache threshold has been reached and
		if so, it will remove the oldest item to get below the threshold.

	InMemoryDashCacheMonitor - Class that implements a timer and calls a delegate method in the InMemoryDashCacheManager each time the timer's elasped event
		fires.

	InMemoryDashCacheGateway - Static object that contains a singleton InMemoryDashCacheManager and exposes methods to interact with the InMemoryDashCacheManager.
		It also contins the Start Method used to start the InMemoryDashCacheMonitor.

	InMemoryDashCacheManager - Contains a static singleton InMemoryDashCache and exposes methods to interact with the cache and also, the expire logic is here.

	InMemoryDashCache - Contains the actual ConcurrencyDictionary that houses the cached items.  It exposes public methods to interact with the cache.

	DashCacheItem - The ConcurrencyDictionary has a signature of <string, DashCacheItem>.  The DashCacheItem class is a wrapper class contains the 
		timestamp of when the object was created and the actual objects ie int, IEnumerable<> etc etc.


Configuration Settings:
	DashCacheEnabled - boolean value used to determine if the DashCache Framework is enabled.

	DashCacheThreshold - integer value that tells the DashCache Framework how many items can be in the cache at any given time.

	DashCacheMonitorInterval - integer in milliseconds that tells the DashCache Framework at what intervals to check for expired items.

	DashCacheExpireCacheItem - integer in minutes that tells the DashCache Framework how long an item can stay in cache before it needs to be expired.

