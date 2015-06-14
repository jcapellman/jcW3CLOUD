#ifndef __BOOKMARKMANAGER__
#define __BOOKMARKMANAGER__

#include "Main.h"
#include "BookmarkItem.h"
#include "FileReader.h"

class BookmarkManager {
	public:
		BookmarkManager(string fileName);
		BookmarkManager();

		bool AddBookmark(string description, string url);
		bool RemoveBook(int id);

		vector<BookmarkItem> GetAll();
	private:
		vector<BookmarkItem> _bookmarks;
};

#endif
