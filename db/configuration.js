// Run with the following
//	mongo.exe localhost/scheduler_staging f:\scheduler\db\configuration.js
//	mongo.exe localhost/scheduler_prod f:\scheduler\db\configuration.js

// Get environment based on database name where name format is expected to include an environment suffix, i.e. scheduler_staging, scheduler_prod etc.
environment = db.getName().split('_').pop().toLowerCase();
if (environment === 'staging')
{
	versionId = NumberInt(1);
	eventIdentifier = "GY17";
	cronExpression = "0 0/1 * 1/1 * ? *";
	creationTimestamp = new Date();
}

if (environment === 'prod')
{
	versionId = NumberInt(1);
	eventIdentifier = "GY17";
	cronExpression = "0 0/1 * 1/1 * ? *";
	creationTimestamp = new Date();
}

function S4() {
    return (((1+Math.random())*0x10000)|0).toString(16).substring(1); 
}

var guid = (S4() + S4() + "-" + S4() + "-4" + S4().substr(0,3) + "-" + S4() + "-" + S4() + S4() + S4()).toLowerCase();

var configuration = 
{
	_id: guid,
	VersionId: versionId,
	EventIdentifier: eventIdentifier,
	CronExpression: cronExpression,
	CreationTimestamp: creationTimestamp,
};

db.configurations.insert(configuration);
