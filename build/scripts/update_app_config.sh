#!/usr/bin/env bash

echo "db env variable + ${MESSAGING_BUS_CONNECTION_STRING}"
MESSAGING_BUS_CONNECTION_STRING_VAR=${MESSAGING_BUS_CONNECTION_STRING}
echo "db env variable + ${DATABASE_CONNECTION_STRING}"
DATABASE_CONNECTION_STRING_VAR=${DATABASE_CONNECTION_STRING}

sed -i "s|\[\[\(messaging_bus_connection_string\)\]\]|"${MESSAGING_BUS_CONNECTION_STRING_VAR}"|g; s|\[\[\(database_connection_string\)\]\]|"${DATABASE_CONNECTION_STRING_VAR}"|g" /home/travis/build/Alanmugz/Scheduler/ide/Scheduler_all/Scheduler/App.config
		
cat /home/travis/build/Alanmugz/Scheduler/ide/Scheduler_all/Scheduler/App.config
