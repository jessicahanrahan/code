module Automation
  class DB < Thor
    namespace :db

    [:create, :delete, :start, :stop].each do |operation|
      instance_eval do
        desc "#{operation}", "#{operation} the local database"
        define_method(operation) do
          `sqllocaldb #{operation} #{settings.database.name}`
        end
      end
    end

    desc 'rebuild', 'rebuild the db'
    def rebuild
      [
        :stop,
        :delete,
        :create,
        :start
      ].each { |task| invoke task }
    end
  end
end
